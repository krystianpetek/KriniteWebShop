using KriniteWebShop.WebUI.Blazor.Models;

namespace KriniteWebShop.WebUI.Blazor.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderModel?>?> GetOrdersByUserNameAsync(string userName);
}
