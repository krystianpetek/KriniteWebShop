using KriniteWebShop.ProductCoupon.gRPC.Data;
using KriniteWebShop.ProductCoupon.gRPC.Protos;
using KriniteWebShop.ProductCoupon.gRPC.Repositories;
using KriniteWebShop.ProductCoupon.gRPC.Services;

namespace KriniteWebShop.ProductCoupon.gRPC;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGrpc();
        builder.Services.AddScoped<ICouponRepository, CouponRepository>();
        builder.Services.AddAutoMapper(typeof(Program));

        var app = builder.Build();

        app.MapGrpcService<CouponService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
        
        app.SeedData();

        app.Run();
    }
}