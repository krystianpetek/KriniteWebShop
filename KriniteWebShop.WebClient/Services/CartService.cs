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

    public async Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel)
    {
        var response = await _httpClient.PostAsJsonAsync<CartCheckoutModel>("/Cart/Checkout", cartCheckoutModel);
        if (response.IsSuccessStatusCode)
            throw new HttpRequestException("Error occured when calling to GatewayAPI.");
        await Task.CompletedTask;
    }

    public async Task<CartModel> GetCartAsync(string userName)
    {
        var response = await _httpClient.GetFromJsonAsync<CartModel>($"/Cart/{userName}");
        return response;
    }

    public async Task<CartModel> UpdateCartAsync(CartModel model)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync<CartModel>($"/Cart/{model?.UserName}",model);
        CartModel? result = await response.Content.ReadFromJsonAsync<CartModel>();
        return result;
    }
}
