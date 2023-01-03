using System.Text.Json.Serialization;

namespace KriniteWebShop.ProductCatalog.API.Entities;

public class RestProduct : IProduct<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
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
