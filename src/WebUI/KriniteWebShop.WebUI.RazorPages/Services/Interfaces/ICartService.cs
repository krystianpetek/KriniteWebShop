using Old_KriniteWebShop.WebUI.RazorPages.Models;

namespace Old_KriniteWebShop.WebUI.RazorPages.Services.Interfaces;

public interface ICartService
{
    Task<CartModel> GetCartAsync(string userName);
    Task<CartModel> UpdateCartAsync(CartModel model);
    Task CartCheckoutAsync(CartCheckoutModel cartCheckoutModel);
}
