using KriniteWebShop.PurchaseAggregator.Models;

namespace KriniteWebShop.PurchaseAggregator.Services.Interfaces;

public interface ICartService
{
    Task<CartModel> GetCartAsync(string userName);
}
