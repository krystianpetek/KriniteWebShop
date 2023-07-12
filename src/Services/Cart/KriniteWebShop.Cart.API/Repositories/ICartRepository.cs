using KriniteWebShop.Cart.API.Entities;

namespace KriniteWebShop.Cart.API.Repositories;

public interface ICartRepository
{
	Task<ShoppingCart> GetCart(string userName);
	Task<ShoppingCart> UpdateCart(ShoppingCart cart);
	Task DeleteCart(string userName);
}
