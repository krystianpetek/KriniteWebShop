using KriniteWebShop.PurchaseAggregator.Models;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;

namespace KriniteWebShop.PurchaseAggregator.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task<ProductModel> GetProductById(string id)
    {
        throw new NotImplementedException();

    }

    public Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }
}
