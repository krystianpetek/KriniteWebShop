using KriniteWebShop.Order.Domain.Entities;

namespace KriniteWebShop.Order.Domain.Repository;
public interface IOrderRepository : IAsyncRepository<OrderEntity>
{
    Task<IEnumerable<OrderEntity>> GetOrdersByUserName(string userName);
}
