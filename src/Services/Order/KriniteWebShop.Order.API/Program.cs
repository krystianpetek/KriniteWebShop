using KriniteWebShop.EventBus.Common;
using KriniteWebShop.Order.API.EventBusConsumer;
using KriniteWebShop.Order.Application;
using KriniteWebShop.Order.Application.Exceptions;
using KriniteWebShop.Order.Infrastructure;
using KriniteWebShop.Order.Infrastructure.Persistance;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using System.Reflection;

namespace KriniteWebShop.Order.API;

public static class Program
{
	public async static Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddApplicationServices();
		builder.Services.AddInfrastructureServices(builder.Configuration);

		builder.Services.AddMassTransit(massTransitConfig =>
		{
			massTransitConfig.AddConsumer<CartCheckoutConsumer>();
			massTransitConfig.UsingRabbitMq((busContext, rabbitMqConfig) =>
			{
				string connectionString = builder.Configuration.GetConnectionString("RabbitMqConnection");
				rabbitMqConfig.Host(connectionString);
				rabbitMqConfig.ReceiveEndpoint(
					queueName: EventBusConstants.CartCheckoutQueue,
					configureEndpoint: endpointConfig =>
				{
					endpointConfig.ConfigureConsumer<CartCheckoutConsumer>(busContext);
				});
			});
		});

		builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
		builder.Services.AddScoped<CartCheckoutConsumer>();

		var app = builder.Build();

		if (app.Environment.IsEnvironment("Docker") || app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();
		app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.ContentType = "application/problem+json";
                    if (context.RequestServices.GetService<IProblemDetailsService>() is { } problemDetailsService)
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var exceptionType = exceptionHandlerFeature?.Error;
                        if (exceptionType is not null)
                        {
                            (string? Title, string? Detail, int? StatusCode) = exceptionType switch
                            {
								ValidationException validationException => (exceptionType.GetType().Name, validationException.Errors.FirstOrDefault().Value.FirstOrDefault(), context.Response.StatusCode = StatusCodes.Status400BadRequest),
								_ => ( exceptionType.GetType().Name, exceptionType.Message, context.Response.StatusCode = StatusCodes.Status500InternalServerError )
                            };
                            var problem = new ProblemDetailsContext
                            {
                                HttpContext = context,
                                ProblemDetails =
                                {
                                    Title = Title,
                                    Detail = Detail,
                                    Status = StatusCode,
                                    Instance = context.Request.Path,
                                    Extensions =
                                    {
                                        ["traceId"] = Activity.Current?.Id ?? context?.TraceIdentifier
                                    }
                                },
                            };
                            if (builder.Environment.IsDevelopment())
                            {
                                problem.ProblemDetails.Extensions.Add("exception", exceptionHandlerFeature?.Error.ToString());
                            }

                            await problemDetailsService.WriteAsync(problem);
                        }
                    }
                });
            });

		await app.MigrateDatabaseAsync<OrderContext>(async (context, provider) =>
		{
			var logger = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<ILogger<OrderContext>>();
			await context.InitialMigrateAsync(logger);
		});

		await app.RunAsync();
	}
}
