using Old_KriniteWebShop.WebClient.Models;

namespace Old_KriniteWebShop.WebClient.Services.Interfaces;

public interface ICartService
{
	Task<CartModel> GetCartAsync(string userName);
	Task<CartModel> UpdateCartAsync(CartModel model);
	Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel);
}
