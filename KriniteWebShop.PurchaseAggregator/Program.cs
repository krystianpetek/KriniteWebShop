
using KriniteWebShop.PurchaseAggregator.Services;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;

namespace KriniteWebShop.PurchaseAggregator;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHttpClient<IProductService, ProductService>(client =>
        {
            string serviceUrl = builder.Configuration.GetRequiredSection("PurchaseServices").GetValue<string>("ProductCatalog");
            client.BaseAddress = new Uri(serviceUrl);
        });
        builder.Services.AddHttpClient<ICartService, CartService>(client =>
        {
            string serviceUrl = builder.Configuration.GetRequiredSection("PurchaseServices").GetValue<string>("ProductCart");
            client.BaseAddress = new Uri(serviceUrl);
        });
        builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
        {
            string serviceUrl = builder.Configuration.GetRequiredSection("PurchaseServices").GetValue<string>("ProductOrder");
            client.BaseAddress = new Uri(serviceUrl);
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
