using KriniteWebShop.Catalog.API.Entities;

namespace KriniteWebShop.Catalog.API.Repositories;

public interface IProductRepository
{
    Task<Product> GetProduct(Guid id);
    IAsyncEnumerable<Product> GetProducts();
    IAsyncEnumerable<Product> GetProductsByName(string name);
    IAsyncEnumerable<Product> GetProductsByCategory(string categoryName);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(Guid id);
}
