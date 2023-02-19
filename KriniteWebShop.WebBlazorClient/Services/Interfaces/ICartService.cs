using KriniteWebShop.WebBlazorClient.Models;

namespace KriniteWebShop.WebBlazorClient.Services.Interfaces;

public interface ICartService
{
    Task<CartModel> GetCartAsync(string userName);
    Task<CartModel> UpdateCartAsync(CartModel model);
    Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel);
}
