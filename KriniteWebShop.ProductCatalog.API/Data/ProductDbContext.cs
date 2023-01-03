using KriniteWebShop.ProductCatalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.ProductCatalog.API.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
