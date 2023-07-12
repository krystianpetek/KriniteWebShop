using KriniteWebShop.WebBlazorClient.Models;
using KriniteWebShop.WebBlazorClient.Services.Interfaces;

namespace KriniteWebShop.WebBlazorClient.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IEnumerable<OrderModel?>?> GetOrdersByUserNameAsync(string userName)
    {
        IEnumerable<OrderModel?>? resultModel = await _httpClient.GetFromJsonAsync<IEnumerable<OrderModel?>?>($"/order/{userName}");
        return resultModel;
    }
}
