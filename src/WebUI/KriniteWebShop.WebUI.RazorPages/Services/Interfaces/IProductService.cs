using Old_KriniteWebShop.WebUI.RazorPages.Models;

namespace Old_KriniteWebShop.WebUI.RazorPages.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string category);
    Task<ProductModel> GetProductById(string id);
    Task<ProductModel> CreateProduct(ProductModel product);
}
