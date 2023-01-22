using KriniteWebShop.WebClient.Services;
using KriniteWebShop.WebClient.Services.Interfaces;

namespace KriniteWebShop.WebClient;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        string gatewayApiUri = builder.Configuration.GetRequiredSection("GatewayApiUri").Value;
        builder.Services.AddHttpClient<IProductService, ProductService>(config => config.BaseAddress = new Uri(gatewayApiUri));
        builder.Services.AddHttpClient<ICartService, CartService>(config => config.BaseAddress = new Uri(gatewayApiUri));
        builder.Services.AddHttpClient<IOrderService, OrderService>(config => config.BaseAddress = new Uri(gatewayApiUri));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
