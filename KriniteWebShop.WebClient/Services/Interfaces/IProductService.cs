using KriniteWebShop.WebClient.Models;

namespace KriniteWebShop.WebClient.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string category);
    Task<ProductModel> GetProductById(string id);
    Task<ProductModel> CreateProduct(ProductModel product);
}
