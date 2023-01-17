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

    public async Task<ProductModel> CreateProduct(ProductModel product)
    {
        var response = await _httpClient.PostAsJsonAsync<ProductModel>("/Product", product);
        var result = await response.Content.ReadFromJsonAsync<ProductModel>();
        return result;
    }

    public async Task<ProductModel> GetProductById(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<ProductModel>($"/Product/{id}");
        return response;
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>("/Product");
        return response;
    }

    public async Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(string categoryName)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"/Product/GetProductsByCategory/{categoryName}");
        return response;
    }
}
