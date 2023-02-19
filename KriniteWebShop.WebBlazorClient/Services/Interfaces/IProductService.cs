using KriniteWebShop.WebBlazorClient.Models;

namespace KriniteWebShop.WebBlazorClient.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string category);
    Task<ProductModel> GetProductById(string id);
    Task<ProductModel> CreateProduct(ProductModel product);
}
