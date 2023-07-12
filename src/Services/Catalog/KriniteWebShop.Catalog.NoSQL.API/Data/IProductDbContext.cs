using KriniteWebShop.Catalog.NoSQL.API.Entities;
using MongoDB.Driver;

namespace KriniteWebShop.Catalog.NoSQL.API.Data;

public interface IProductDbContext
{
	IMongoCollection<Product> Products { get; }
}
