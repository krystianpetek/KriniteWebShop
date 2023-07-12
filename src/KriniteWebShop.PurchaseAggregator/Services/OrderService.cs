using KriniteWebShop.PurchaseAggregator.Models;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;

namespace KriniteWebShop.PurchaseAggregator.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<OrderModel>>($"/api/v1/Order/{userName}");
        return response;
    }
}
