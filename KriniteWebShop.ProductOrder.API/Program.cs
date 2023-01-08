using KriniteWebShop.ProductOrder.Application;
using KriniteWebShop.ProductOrder.Infrastructure;
using KriniteWebShop.ProductOrder.Infrastructure.Persistance;

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

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
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
