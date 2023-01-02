using KriniteWebShop.Catalog.API.Entities;

namespace KriniteWebShop.Catalog.API.Repositories;

public interface IProductRepository
{
    Task<Product> GetProduct(Guid id);
    Task<IReadOnlyCollection<Product>> GetProducts();
    Task<IReadOnlyCollection<Product>> GetProductsWithFilter(Func<Product,bool> filter);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(Guid id);
}
