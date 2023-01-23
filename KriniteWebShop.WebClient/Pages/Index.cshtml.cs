﻿using KriniteWebShop.WebClient.Models;
using KriniteWebShop.WebClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KriniteWebShop.WebClient.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public IEnumerable<Models.ProductModel> ProductList { get; set; } = new List<Models.ProductModel>();
    public string UserName { get; set; } = "krystianpetek2";

    public IndexModel(ILogger<IndexModel> logger, ICartService cartService, IProductService productService)
    {
        _logger = logger;
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    public async Task<IActionResult> OnGetAsync()
    {
        ProductList = await _productService.GetProductsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAddProductToCartAsync(string productId)
    {
        Models.ProductModel product = await _productService.GetProductById(productId);
        Models.CartModel cart = await _cartService.GetCartAsync(User.Identity.Name ?? UserName);

        CartItemModel newItem = new CartItemModel
        {
            ProductId = productId,
            ProductName = product.Name,
            Price = product.Price,
            Quantity = 1,
        };
        cart.Items.Add(newItem);

        await _cartService.UpdateCartAsync(cart);

        return RedirectToPage("Cart");
    }
}
