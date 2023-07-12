using KriniteWebShop.WebUI.Blazor.Services;
using KriniteWebShop.WebUI.Blazor.Models;
using KriniteWebShop.WebUI.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace KriniteWebShop.WebUI.Blazor.Pages;

public partial class Checkout
{
    private CartCheckoutModel cartCheckoutModel = new CartCheckoutModel();

    [Parameter]
    public string UserName { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    [Inject]
    private ICartService? CartService { get; set; }

    private async Task CheckoutCart()
    {
        cartCheckoutModel.UserName = UserName;

        await CartService.CartCheckoutAsync(cartCheckoutModel);
    }

    private async Task OnValidSubmit()
    {
        NavigationManager.NavigateTo("/order");
    }
}
