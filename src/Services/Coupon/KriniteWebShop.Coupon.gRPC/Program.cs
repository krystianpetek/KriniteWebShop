using KriniteWebShop.Coupon.gRPC.Data;
using KriniteWebShop.Coupon.gRPC.Repositories;
using KriniteWebShop.Coupon.gRPC.Services;
using KriniteWebShop.Coupon.gRPC.Protos;

namespace KriniteWebShop.Coupon.gRPC;
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