using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Entities;

public class RestProduct : IProduct<string>
{
    [JsonIgnore, BsonIgnore]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Product ToProduct(string id = default)
    {
        return new Product
        {
            Id = id,
            Name = Name,
            Category = Category,
            Description = Description,
            Price = Price
        };
    }
}
