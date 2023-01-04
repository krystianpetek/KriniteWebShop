using KriniteWebShop.ProductCatalog.NoSQL.API.Entities;
using MongoDB.Driver;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Data;

public class ProductDbContext : IProductDbContext
{
    public ProductDbContext(IConfiguration config)
    {
        var connectionString = config.GetRequiredSection("DatabaseSettings");
        IMongoClient client = new MongoClient(connectionString.GetValue<string>("ConnectionString"));
        IMongoDatabase database = client.GetDatabase(connectionString.GetValue<string>("DatabaseName"));
        Products = database.GetCollection<Product>(connectionString.GetValue<string>("CollectionName"));
    }
    public IMongoCollection<Product> Products { get; init; }

}
