using Microsoft.OpenApi.Models;

namespace KriniteWebShop.ProductCoupon.API;

public class Program
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
                    Title = "ProductCoupon.API",
                    Version = "v1"
                });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI((swaggerUi) =>
            {
                swaggerUi.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "ProductCoupon.API v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
