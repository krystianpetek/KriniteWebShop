using KriniteWebShop.WebUI.Blazor.Models;
using KriniteWebShop.WebUI.Blazor.Services.Interfaces;

namespace KriniteWebShop.WebUI.Blazor.Services;

public class CartService : ICartService
{
    private readonly HttpClient _httpClient;
    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel)
    {
        HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync("/cart/Checkout", cartCheckoutModel);
        if (!httpResponse.IsSuccessStatusCode)
            throw new HttpRequestException($"Error occured when calling to GatewayAPI.\nStatus code: {httpResponse.StatusCode}");
        await Task.CompletedTask;
    }

    public async Task<CartModel?> GetCartAsync(string userName)
    {
        CartModel? resultModel = await _httpClient.GetFromJsonAsync<CartModel>($"/cart/{userName}");
        return resultModel;
    }

    public async Task<CartModel?> UpdateCartAsync(CartModel model)
    {
        HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync($"/cart/{model.UserName}", model);
        CartModel? resultModel = await httpResponse.Content.ReadFromJsonAsync<CartModel>();
        return resultModel;
    }
}
