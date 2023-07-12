using KriniteWebShop.WebUI.Blazor.Models;

namespace KriniteWebShop.WebUI.Blazor.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel?>?> GetProductsAsync();
    Task<IEnumerable<ProductModel?>?> GetProductsByCategoryAsync(string category);
    Task<ProductModel?> GetProductByIdAsync(string id);
    Task<ProductModel?> CreateProductAsync(ProductModel product);
}
