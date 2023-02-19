using KriniteWebShop.WebBlazorClient.Models;

namespace KriniteWebShop.WebBlazorClient.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel?>?> GetProductsAsync();
    Task<IEnumerable<ProductModel?>?> GetProductsByCategoryAsync(string category);
    Task<ProductModel?> GetProductByIdAsync(string id);
    Task<ProductModel?> CreateProductAsync(ProductModel product);
}
