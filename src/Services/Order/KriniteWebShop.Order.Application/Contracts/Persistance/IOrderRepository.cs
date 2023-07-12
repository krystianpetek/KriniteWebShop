using KriniteWebShop.Order.Domain.Entities;

namespace KriniteWebShop.Order.Application.Contracts.Persistance;
public interface IOrderRepository : IAsyncRepository<OrderEntity>
{
	Task<IEnumerable<OrderEntity>> GetOrdersByUserName(string userName);
}
