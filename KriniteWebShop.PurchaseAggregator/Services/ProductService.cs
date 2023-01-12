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

    public async Task<ProductModel> GetProductById(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<ProductModel>($"/api/v1/Product/{id}");
        return response;
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("/api/v1/Product");
        return response;
    }

    public async Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string categoryName)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"/api/v1/Product/GetProductsByCategory/{categoryName}");
        return response;
    }
}
