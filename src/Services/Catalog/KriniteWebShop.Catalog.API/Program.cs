using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Old_KriniteWebShop.Catalog.API.Data;
using Old_KriniteWebShop.Catalog.API.Repositories;

namespace Old_KriniteWebShop.Catalog.API;

/// <summary>
/// This project is deprecated use KriniteWebShop.ProductCatalog.NoSQL.API instead.
/// </summary>
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
					Title = "ProductCatalog.API",
					Version = "v1"
				});
		});

		builder.Services.AddDbContext<ProductDbContext>(
			(options) =>
			{
				var connectionString = builder.Configuration.GetRequiredSection("ConnectionStrings").GetValue<string>("ProductConnection");
				options.UseSqlServer(connectionString);
			});

		builder.Services.AddScoped<IProductRepository, ProductRepository>();

		var app = builder.Build();

		if (app.Environment.IsEnvironment("Docker") || app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI((swaggerUi) =>
			{
				swaggerUi.SwaggerEndpoint(
					url: "/swagger/v1/swagger.json",
					name: "ProductCatalog.API v1");
			});
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.SeedData();

		app.Run();
	}
}
