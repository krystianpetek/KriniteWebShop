using KriniteWebShop.WebBlazorClient.Models;
using KriniteWebShop.WebBlazorClient.Services.Interfaces;
using KriniteWebShop.WebBlazorClient.State;
using Microsoft.AspNetCore.Components;

namespace KriniteWebShop.WebBlazorClient.Pages;

public partial class Cart : ComponentBase
{
    [Inject]
    private ICartService? CartService { get; set; }

    [Inject]
    private ICartState? CartState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private string? UserName { get; set; }

    private Models.CartModel? CartModelProp { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrWhiteSpace(UserName))
            CartModelProp = await CartService!.GetCartAsync(UserName);
    }

    private async Task FetchData()
    {
        if (!string.IsNullOrWhiteSpace(UserName))
        {
            CartModelProp = await CartService!.GetCartAsync(UserName);
            var grouped = from cartItems in CartModelProp.Items
                          group cartItems by cartItems.ProductId into cartSumItems
                          select new
                          {
                              A = cartSumItems.Key,
                              B = cartSumItems.Sum(x => x.Quantity)
                          };

            var aggregated = CartModelProp.Items
                .GroupBy(cart => cart.ProductId)
                .Select(c =>
                new CartItemModel(c.First().ProductId, c.First().ProductName, c.Sum(d => d.Quantity), c.First().Price));

            CartState!.SetState(CartModelProp.Items.Count());

            CartModelProp = CartModelProp with
            {
                Items = aggregated
            };

        }
    }

    private void CheckoutCart()
    {
        if (CartModelProp?.Items?.Count() > 0)
        {
            NavigationManager.NavigateTo($"/checkout/{UserName}");
        }
    }
}
