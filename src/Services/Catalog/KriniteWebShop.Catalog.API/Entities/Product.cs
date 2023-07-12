namespace Old_KriniteWebShop.Catalog.API.Entities;

public class Product : IProduct<Guid>
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Category { get; set; }

	public string Description { get; set; }

	public decimal Price { get; set; }
}
