using KriniteWebShop.WebUI.Blazor.Services;
using KriniteWebShop.WebUI.Blazor.Services.Interfaces;
using KriniteWebShop.WebUI.Blazor.State;
using Microsoft.AspNetCore.Components.Authorization;

namespace KriniteWebShop.WebUI.Blazor;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.WebHost.UseStaticWebAssets(); // to fix css isolation in docker

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<ICartState, CartState>();

        string? gatewayApiUri = builder.Configuration.GetRequiredSection("GatewayApiUri")?.Value;
        builder.Services.AddHttpClient<IProductService, ProductService>(config => config.BaseAddress = new Uri(gatewayApiUri!));
        builder.Services.AddHttpClient<ICartService, CartService>(config => config.BaseAddress = new Uri(gatewayApiUri!));
        builder.Services.AddHttpClient<IOrderService, OrderService>(config => config.BaseAddress = new Uri(gatewayApiUri!));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}
