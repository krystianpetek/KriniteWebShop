using KriniteWebShop.Catalog.API.Data.SqlContext;
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
            (DbContextOptionsBuilder context) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("ProductsConnection");
                context.UseSqlServer(connectionString);
            });

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
