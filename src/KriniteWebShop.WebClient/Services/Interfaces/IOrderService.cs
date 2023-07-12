using Old_KriniteWebShop.WebClient.Models;

namespace Old_KriniteWebShop.WebClient.Services.Interfaces;

public interface IOrderService
{
	Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName);
}
