using KriniteWebShop.PurchaseAggregator.Models;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;

namespace KriniteWebShop.PurchaseAggregator.Services;

public class CartService : ICartService
{
    private readonly HttpClient _httpClient;
    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CartModel> GetCartAsync(string userName)
    {
        var response = await _httpClient.GetFromJsonAsync<CartModel>($"/api/v1/Cart/{userName}");
        return response;
    }
}
