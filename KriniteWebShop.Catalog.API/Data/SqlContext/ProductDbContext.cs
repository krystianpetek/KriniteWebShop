using KriniteWebShop.Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.Catalog.API.Data.SqlContext;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
