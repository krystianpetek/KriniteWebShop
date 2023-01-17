using KriniteWebShop.WebClient.Models;

namespace KriniteWebShop.WebClient.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName);
}
