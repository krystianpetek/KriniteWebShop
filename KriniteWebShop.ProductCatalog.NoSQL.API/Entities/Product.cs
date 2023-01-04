using MongoDB.Bson.Serialization.Attributes;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Entities;

public class Product : IProduct<string>
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}
