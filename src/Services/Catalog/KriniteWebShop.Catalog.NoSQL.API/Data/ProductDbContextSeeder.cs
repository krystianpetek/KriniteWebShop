using KriniteWebShop.Catalog.NoSQL.API.Entities;
using MongoDB.Driver;

namespace KriniteWebShop.Catalog.NoSQL.API.Data;

public static class ProductDbContextSeeder
{
	public static void SeedData(this IApplicationBuilder app)
	{
		IProductDbContext productCollection = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IProductDbContext>();

		if (!productCollection.Products.Find(product => true).Any())
		{
			productCollection.Products.InsertManyAsync(
				new List<Product>()
				{
					new Product
					{
						Id = "63b7e270f54587da0241b103",
						Name = "Kayak",
						Description = "A boat for one person",
						Category = "Watersports",
						Price = 275.00m
					},
					new Product
					{
						Id = "63b7e2764879d2c3ec62f9c0",
						Name = "Lifejacket",
						Description = "Protective and fashionable",
						Category = "Watersports",
						Price = 48.95m
					},
					new Product
					{
						Id = "63b7e290da99ef8b6606848b",
						Name = "Soccer Ball",
						Description = "FIFA-approved size and weight",
						Category = "Soccer",
						Price = 19.50m
					},
					new Product
					{
						Id = "63b7e2946aae85cd3ec1e28e",
						Name = "Corner Flags",
						Description = "Give your playing field a professional touch",
						Category = "Soccer",
						Price = 34.95m
					},
					new Product
					{
						Id = "63b7e29dc1a358f7d360faf5",
						Name = "Stadium",
						Description = "Flat-packed 35,000-seat stadium",
						Category = "Soccer",
						Price = 79500.00m
					},
					new Product
					{
						Id = "63b7e2a0214787bc4213a60f",
						Name = "Thinking Cap",
						Description = "Improve brain efficiency by 75%",
						Category = "Chess",
						Price = 16.00m
					},
					new Product
					{
						Id = "63b7e2a42eef52c3bd9239fc",
						Name = "Unsteady Chair",
						Description = "Secretly give your opponent a disadvantage",
						Category = "Chess",
						Price = 29.95m
					},
					new Product
					{
						Id = "63b7e2a8113a3740c651d7e6",
						Name = "Human Chess Board",
						Description = "A fun game for the family",
						Category = "Chess",
						Price = 75.00m
					},
					new Product
					{
						Id = "63b7e2ace177385e3d05fdbe",
						Name = "Bling-Bling King",
						Description = "Gold-plated, diamond-studded King",
						Category = "Chess",
						Price = 1200.00m
					}
				});
		}
	}
}
