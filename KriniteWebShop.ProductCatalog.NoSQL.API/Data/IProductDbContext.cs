using KriniteWebShop.ProductCatalog.NoSQL.API.Entities;
using MongoDB.Driver;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Data;

public interface IProductDbContext
{
    IMongoCollection<Product> Products { get; }
}
