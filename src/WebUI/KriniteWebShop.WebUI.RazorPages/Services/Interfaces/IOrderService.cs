using Old_KriniteWebShop.WebUI.RazorPages.Models;

namespace Old_KriniteWebShop.WebUI.RazorPages.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName);
}
