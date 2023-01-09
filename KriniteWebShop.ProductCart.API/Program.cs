using KriniteWebShop.ProductCart.API.GrpcServices;
using KriniteWebShop.ProductCart.API.Repositories;
using KriniteWebShop.ProductCoupon.gRPC.Protos;
using MassTransit;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace KriniteWebShop.ProductCart.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen((swagger) =>
        {
            swagger.SwaggerDoc(
                name: "v1",
                info: new OpenApiInfo
                {
                    Title = "ProductCart.API",
                    Version = "v1"
                });
        });

        builder.Services.AddStackExchangeRedisCache((RedisCacheOptions redis) =>
        {
            string connectionString = builder.Configuration?.GetRequiredSection("CacheSettings")?.GetValue<string>("CartConnection");
            redis.Configuration = connectionString;
        });

        builder.Services.AddGrpcClient<CouponProtoService.CouponProtoServiceClient>(configureClient =>
        {
            var couponUrl = builder.Configuration.GetRequiredSection("GrpcSettings").GetValue<string>("CouponConnection");
            configureClient.Address = new Uri(couponUrl);
        });

        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<CouponGrpcService>();

        builder.Services.AddMassTransit(massTransitConfig =>
        {
            massTransitConfig.UsingRabbitMq((busContext,rabbitMqConfig) =>
            {
                string connectionString = builder.Configuration.GetConnectionString("RabbitMqConnection");
                rabbitMqConfig.Host(connectionString); 
            });
        });
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        if (app.Environment.IsEnvironment("Docker") || app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI((swaggerUi) =>
            {
                swaggerUi.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "ProductCart.API v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
