using KriniteWebShop.ProductCatalog.API.Data;
using KriniteWebShop.ProductCatalog.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KriniteWebShop.ProductCatalog.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen((swagger) =>
        {
            swagger.SwaggerDoc(
                name: "v1",
                info: new OpenApiInfo
                {
                    Title = "Catalog.API",
                    Version = "v1"
                });
        });

        builder.Services.AddDbContext<ProductDbContext>(
            (options) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("ProductsConnection");
                options.UseSqlServer(connectionString);
            });

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddDistributedMemoryCache();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI((swaggerUi) =>
            {
                swaggerUi.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Product.API v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.SeedData();

        app.Run();
    }
}
