using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Entities;

public record RestProduct : IProduct<string>
{
    [JsonIgnore, BsonIgnore]
    public string? Id { get; init; }

    [BsonElement("Name")]
    [MinLength(3)]
    [StringLength(50)]
    public string Name { get; init; }

    [MinLength(3)]
    [StringLength(30)]
    public string Category { get; init; }

    [MinLength(3)]
    [StringLength(100)]
    public string Description { get; init; }

    [RegularExpression(@"^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$", ErrorMessage = "Price must be greather than 0.")]
    public decimal Price { get; init; }

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
