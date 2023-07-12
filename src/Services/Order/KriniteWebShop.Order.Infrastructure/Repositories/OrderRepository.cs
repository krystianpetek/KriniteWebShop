using KriniteWebShop.Order.Application.Contracts.Persistance;
using KriniteWebShop.Order.Domain.Entities;
using KriniteWebShop.Order.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KriniteWebShop.Order.Infrastructure.Repositories;
public class OrderRepository : AsyncRepository<OrderEntity>, IOrderRepository
{

	public OrderRepository(OrderContext orderContext) : base(orderContext) { }

	public async Task<IEnumerable<OrderEntity>> GetOrdersByUserName(string userName)
	{
		IEnumerable<OrderEntity> orders = await _orderContext.Orders
			.Where(user => user.UserName == userName)
			.ToListAsync();

		return orders;
	}
}
