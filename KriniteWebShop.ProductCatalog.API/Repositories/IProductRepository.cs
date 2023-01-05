using KriniteWebShop.ProductCatalog.API.Entities;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductCatalog.API.Repositories;

public interface IProductRepository
{
    Task<Product> GetProductById(Guid id);
    Task<IEnumerable<Product>> GetProducts();
    Task<IEnumerable<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Guid id, RestProduct product);
    Task<bool> DeleteProduct(Guid id);
}
