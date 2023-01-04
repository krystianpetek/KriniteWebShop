using KriniteWebShop.ProductCart.API.Entities;

namespace KriniteWebShop.ProductCart.API.Repositories;

public interface ICartRepository
{
    Task<ShoppingCart> GetCart(string userName);
    Task<ShoppingCart> UpdateCart(ShoppingCart cart);
    Task DeleteCart(string userName);
}
