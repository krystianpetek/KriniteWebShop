using KriniteWebShop.WebClient.Models;
using KriniteWebShop.WebClient.Services.Interfaces;

namespace KriniteWebShop.WebClient.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task<ProductModel> CreateProduct(ProductModel product)
    {
        throw new NotImplementedException();
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
