using Microsoft.EntityFrameworkCore;
using Old_KriniteWebShop.Catalog.API.Entities;

namespace Old_KriniteWebShop.Catalog.API.Data;

public class ProductDbContext : DbContext
{
	public ProductDbContext(DbContextOptions options) : base(options) { }

	public DbSet<Product> Products { get; set; }
}
