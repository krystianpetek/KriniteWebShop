using KriniteWebShop.ProductCatalog.NoSQL.API.Entities;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductCatalog.NoSQL.API.Repositories;

public interface IProductRepository
{
    Task<Product> GetProductById(string id);
    Task<IEnumerable<Product>> GetProducts(); 
    Task<IEnumerable<string>> GetProductCategories();
    Task<IEnumerable<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(string id, RestProduct restProduct);
    Task<bool> DeleteProduct(string id);
}
