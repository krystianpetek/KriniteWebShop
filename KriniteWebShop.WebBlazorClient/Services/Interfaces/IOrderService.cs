using KriniteWebShop.WebBlazorClient.Models;

namespace KriniteWebShop.WebBlazorClient.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderModel?>?> GetOrdersByUserNameAsync(string userName);
}
