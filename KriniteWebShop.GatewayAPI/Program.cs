using Microsoft.OpenApi.Models;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace KriniteWebShop.GatewayAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging
            .AddConfiguration(builder.Configuration.GetRequiredSection("Logging"))
            .AddConsole()
            .AddDebug();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen((swagger) =>
        {
            swagger.SwaggerDoc(
                name: "v1",
                info: new OpenApiInfo
                {
                    Title = "GatewayAPI",
                    Version = "v1"
                });
        });

        builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

        builder.Services.AddOcelot()
            .AddCacheManager(cacheManager => cacheManager.WithDictionaryHandle());

        var app = builder.Build();
        app.UseCors(cors =>
        {
            cors.AllowAnyOrigin();
        });
        app.UseSwagger();
        app.UseSwaggerUI(swagger =>
        {
            swagger.SwaggerEndpoint(
                    url: "http://localhost:5821/swagger/v1/swagger.json",
                    name: "api v1");

        });

        await app.UseOcelot();

        app.Run();
    }
}
