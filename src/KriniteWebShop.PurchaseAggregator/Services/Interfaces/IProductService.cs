using KriniteWebShop.PurchaseAggregator.Models;

namespace KriniteWebShop.PurchaseAggregator.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string category);
    Task<ProductModel> GetProductById(string id);
}
