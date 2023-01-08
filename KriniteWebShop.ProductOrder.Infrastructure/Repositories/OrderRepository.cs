using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Domain.Entities;
using KriniteWebShop.ProductOrder.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductOrder.Infrastructure.Repositories;
public class OrderRepository : AsyncRepository<Order>, IOrderRepository
{

    public OrderRepository(OrderContext orderContext) : base(orderContext) { }

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        IEnumerable<Order> orders = await _orderContext.Orders
            .Where(user => user.UserName == userName)
            .ToListAsync();

        return orders;
    }
}
