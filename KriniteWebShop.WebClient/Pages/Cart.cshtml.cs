using KriniteWebShop.WebClient.Models;
using KriniteWebShop.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KriniteWebShop.WebClient.Pages;

public class CartModel : PageModel
{
    private readonly ICartService _cartService;
    private readonly ILogger<CartModel> _logger;
    public Models.CartModel _cartModel { get; set; }

    public string UserName { get; set; } = "krystianpetek2";

    public CartModel(ILogger<CartModel> logger, ICartService cartService, IProductService productService)
    {
        _logger = logger;
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    public async Task<IActionResult> OnGetAsync()
    {
        _cartModel = await _cartService.GetCartAsync(UserName);
        return Page();
    }
}
