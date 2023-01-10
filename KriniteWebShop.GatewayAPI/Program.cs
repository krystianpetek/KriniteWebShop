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

        builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

        builder.Services.AddOcelot();

        var app = builder.Build();

        await app.UseOcelot();

        app.Run();
    }
}
