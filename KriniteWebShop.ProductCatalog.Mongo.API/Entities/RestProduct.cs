using KriniteWebShop.ProductCatalog.Mongo.API.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace KriniteWebShop.ProductCatalog.Mongo.API.Entities;

public class RestProduct : IProduct<string>
{
    [JsonIgnore]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Product ToProduct()
    {
        return new Product
        {
            Name = Name,
            Category = Category,
            Description = Description,
            Price = Price
        };
    }
}
