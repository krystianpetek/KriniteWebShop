using KriniteWebShop.Catalog.API.Data.SqlContext;
using KriniteWebShop.Catalog.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.Catalog.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ProductDbContext>(
            (DbContextOptionsBuilder options) =>
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
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.SeedData();

        app.Run();
    }
}
