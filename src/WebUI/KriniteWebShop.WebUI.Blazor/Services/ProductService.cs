using KriniteWebShop.WebUI.Blazor.Models;
using KriniteWebShop.WebUI.Blazor.Services.Interfaces;
using System.Net.Http.Json;

namespace KriniteWebShop.WebUI.Blazor.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<ProductModel?> CreateProductAsync(ProductModel product)
    {
        HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync("/product", product);
        ProductModel? resultModel = await httpResponse.Content.ReadFromJsonAsync<ProductModel>();
        return resultModel;
    }

    public async Task<ProductModel?> GetProductByIdAsync(string id)
    {
        ProductModel? resultModel = await _httpClient.GetFromJsonAsync<ProductModel>($"/product/{id}");
        return resultModel;
    }

    public async Task<IEnumerable<ProductModel?>?> GetProductsAsync()
    {
        IEnumerable<ProductModel?>? resultModel = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel?>?>($"/product");
        return resultModel;
    }

    public async Task<IEnumerable<ProductModel?>?> GetProductsByCategoryAsync(string category)
    {
        IEnumerable<ProductModel?>? productModel = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel?>?>("/product/{category}");
        return productModel;
    }
}
