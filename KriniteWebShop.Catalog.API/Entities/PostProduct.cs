namespace KriniteWebShop.Catalog.API.Entities;

public class PostProduct
{
    public string Name { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Product ToProduct()
    {
        return new Product
        {
            Name = this.Name,
            Category = this.Category,
            Description = this.Description,
            Price = this.Price
        };
    }
}
