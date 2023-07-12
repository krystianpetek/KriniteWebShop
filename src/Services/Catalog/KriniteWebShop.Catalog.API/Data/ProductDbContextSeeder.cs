using Microsoft.EntityFrameworkCore;

namespace Old_KriniteWebShop.Catalog.API.Data;

public static class ProductDbContextSeeder
{
	public static void SeedData(this IApplicationBuilder app)
	{
		ProductDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ProductDbContext>();

		if (context.Database.IsRelational() && context.Database.GetPendingMigrations().Any())
			context.Database.Migrate();

		if (!context.Products.Any())
		{
			context.Products.AddRange(
				new Entities.Product
				{
					Id = Guid.Parse("bbc8d3f2-e9d6-4098-aaee-df176fa40e83"),
					Name = "Kayak",
					Description = "A boat for one person",
					Category = "Watersports",
					Price = 275.00m
				},
				new Entities.Product
				{
					Id = Guid.Parse("e4f54c29-8531-4028-bb50-2b2e9ec2283f"),
					Name = "Lifejacket",
					Description = "Protective and fashionable",
					Category = "Watersports",
					Price = 48.95m
				},
				new Entities.Product
				{
					Id = Guid.Parse("e42800c4-4f8e-45c2-938f-f147a43d7227"),
					Name = "Soccer Ball",
					Description = "FIFA-approved size and weight",
					Category = "Soccer",
					Price = 19.50m
				},
				new Entities.Product
				{
					Id = Guid.Parse("00560f88-a1a8-4d69-8fbd-8d478c469a63"),
					Name = "Corner Flags",
					Description = "Give your playing field a professional touch",
					Category = "Soccer",
					Price = 34.95m
				},
				new Entities.Product
				{
					Id = Guid.Parse("a17aa2e4-74a7-490e-92ef-fa1982f36842"),
					Name = "Stadium",
					Description = "Flat-packed 35,000-seat stadium",
					Category = "Soccer",
					Price = 79500.00m
				},
				new Entities.Product
				{
					Id = Guid.Parse("ae2299a4-40bf-4ac3-8040-000da595c633"),
					Name = "Thinking Cap",
					Description = "Improve brain efficiency by 75%",
					Category = "Chess",
					Price = 16.00m
				},
				new Entities.Product
				{
					Id = Guid.Parse("25b82f94-99de-460e-a491-8729df766edc"),
					Name = "Unsteady Chair",
					Description = "Secretly give your opponent a disadvantage",
					Category = "Chess",
					Price = 29.95m
				},
				new Entities.Product
				{
					Id = Guid.Parse("74cbeda4-f8f7-430c-9c38-f8f25662c598"),
					Name = "Human Chess Board",
					Description = "A fun game for the family",
					Category = "Chess",
					Price = 75.00m
				},
				new Entities.Product
				{
					Id = Guid.Parse("8dd0beea-99a8-4d21-85c5-dfd3321e366c"),
					Name = "Bling-Bling King",
					Description = "Gold-plated, diamond-studded King",
					Category = "Chess",
					Price = 1200.00m
				}
			);

			context.SaveChanges();
		}
	}
}
