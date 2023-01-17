using KriniteWebShop.WebClient.Models;
using KriniteWebShop.WebClient.Services.Interfaces;

namespace KriniteWebShop.WebClient.Services;

public class CartService : ICartService
{
    private readonly HttpClient _httpClient;
    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel)
    {
        throw new NotImplementedException();
    }

    public async Task<CartModel> GetCartAsync(string userName)
    {
        var response = await _httpClient.GetFromJsonAsync<CartModel>($"/api/v1/Cart/{userName}");
        return response;
    }

    public Task<CartModel> UpdateCartAsync(CartModel model)
    {
        throw new NotImplementedException();
    }
}
