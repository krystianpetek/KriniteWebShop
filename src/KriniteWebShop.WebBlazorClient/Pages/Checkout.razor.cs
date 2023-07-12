using KriniteWebShop.WebBlazorClient.Models;
using KriniteWebShop.WebBlazorClient.Services;
using KriniteWebShop.WebBlazorClient.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace KriniteWebShop.WebBlazorClient.Pages;

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
        cartCheckoutModel.UserName = this.UserName;

        await CartService.CartCheckoutAsync(cartCheckoutModel);
    }

    private async Task OnValidSubmit()
    {
        NavigationManager.NavigateTo("/order");
    }
}
