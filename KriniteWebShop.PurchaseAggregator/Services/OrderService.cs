using KriniteWebShop.PurchaseAggregator.Models;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;

namespace KriniteWebShop.PurchaseAggregator.Services;

public class OrderService : IOrderService
{
    public OrderService()
    {

    }

    public Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }
}
