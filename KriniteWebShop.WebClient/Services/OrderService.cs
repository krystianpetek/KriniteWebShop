using KriniteWebShop.WebClient.Models;
using KriniteWebShop.WebClient.Services.Interfaces;

namespace KriniteWebShop.WebClient.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<OrderModel>>($"/api/v1/Order/{userName}");
        return response;
    }
}
