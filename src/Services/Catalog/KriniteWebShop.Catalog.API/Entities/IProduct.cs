namespace Old_KriniteWebShop.Catalog.API.Entities;

public interface IProduct<T>
{
	public T Id { get; set; }

	public string Name { get; set; }

	public string Category { get; set; }

	public string Description { get; set; }

	public decimal Price { get; set; }
}
