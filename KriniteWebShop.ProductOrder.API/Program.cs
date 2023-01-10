using KriniteWebShop.EventBus.Common;
using KriniteWebShop.ProductOrder.API.EventBusConsumer;
using KriniteWebShop.ProductOrder.Application;
using KriniteWebShop.ProductOrder.Infrastructure;
using KriniteWebShop.ProductOrder.Infrastructure.Persistance;
using MassTransit;
using System.Reflection;

namespace KriniteWebShop.ProductOrder.API;

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
                rabbitMqConfig.ReceiveEndpoint(EventBusConstants.CartCheckoutQueue, endpointConfig =>
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

        await app.MigrateDatabaseAsync<OrderContext>(async (context, provider) =>
        {
            var logger = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<ILogger<OrderContext>>();
            await context.InitialMigrateAsync(logger);
        });

        await app.RunAsync();
    }
}
