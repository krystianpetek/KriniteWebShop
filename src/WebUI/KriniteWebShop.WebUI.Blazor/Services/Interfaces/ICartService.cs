using KriniteWebShop.WebUI.Blazor.Models;

namespace KriniteWebShop.WebUI.Blazor.Services.Interfaces;

public interface ICartService
{
    Task<CartModel?> GetCartAsync(string userName);
    Task<CartModel?> UpdateCartAsync(CartModel model);
    Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel);
}
