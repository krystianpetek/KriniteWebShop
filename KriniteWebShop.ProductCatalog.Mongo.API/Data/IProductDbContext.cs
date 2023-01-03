using KriniteWebShop.ProductCatalog.Mongo.API.Entities;
using MongoDB.Driver;

namespace KriniteWebShop.ProductCatalog.Mongo.API.Data;

public interface IProductDbContext
{
    IMongoCollection<Product> Products { get; }
}
