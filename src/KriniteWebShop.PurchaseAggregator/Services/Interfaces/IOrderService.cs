using KriniteWebShop.PurchaseAggregator.Models;

namespace KriniteWebShop.PurchaseAggregator.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName);
}
