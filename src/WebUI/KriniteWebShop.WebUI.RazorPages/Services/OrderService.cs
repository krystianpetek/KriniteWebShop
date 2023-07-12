using Old_KriniteWebShop.WebUI.RazorPages.Models;
using Old_KriniteWebShop.WebUI.RazorPages.Services.Interfaces;

namespace Old_KriniteWebShop.WebUI.RazorPages.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<OrderModel>>($"/Order/{userName}");
        return response;
    }
}
