using KriniteWebShop.PurchaseAggregator.Models;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;

namespace KriniteWebShop.PurchaseAggregator.Services;

public class CartService : ICartService
{

    public CartService()
    {

    }

    public Task<CartModel> GetCartAsync(string userName)
    {
        throw new NotImplementedException();
    }
}
