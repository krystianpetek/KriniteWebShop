using KriniteWebShop.ProductCatalog.Mongo.API.Data;
using KriniteWebShop.ProductCatalog.Mongo.API.Repositories;
using Microsoft.OpenApi.Models;

namespace KriniteWebShop.ProductCatalog.Mongo.API;

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
                    Title = "ProductCatalog.Mongo.API",
                    Version = "v1"
                });
        });

        builder.Services.AddScoped<IProductDbContext, ProductDbContext>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI((swaggerUi) =>
            {
                swaggerUi.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "ProductCatalog.Mongo.API v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.SeedData();

        app.Run();
    }
}
