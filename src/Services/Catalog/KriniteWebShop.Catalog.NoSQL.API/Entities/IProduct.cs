namespace KriniteWebShop.Catalog.NoSQL.API.Entities;

public interface IProduct<T>
{
	public T Id { get; init; }

	public string Name { get; init; }

	public string Category { get; init; }

	public string Description { get; init; }

	public decimal Price { get; init; }
}
