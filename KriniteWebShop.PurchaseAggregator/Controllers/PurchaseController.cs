using KriniteWebShop.PurchaseAggregator.Models;
using KriniteWebShop.PurchaseAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.PurchaseAggregator.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;
    private readonly IOrderService _orderService;
    private readonly ILogger<PurchaseController> _logger;

    public PurchaseController(IProductService productService, ICartService cartService, IOrderService orderService, ILogger<PurchaseController> logger)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("{userName}", Name ="GetPurchase")]
    public async Task<ActionResult<PurchaseModel>> GetPurchase(string userName)
    {
        _logger.LogInformation($"Invoked method {nameof(GetPurchase)} for user name: {userName} in {nameof(PurchaseController)}");

        var cart = await _cartService.GetCartAsync(userName);
        foreach(CartItemModel cartItem in cart?.Items)
        {
            var product = await _productService.GetProductById(cartItem?.ProductId);
            cartItem.Description = product.Description;
            cartItem.Category = product.Category;
        }

        PurchaseModel purchase = new PurchaseModel
        {
            UserName = userName,
            Cart = cart,
            Orders = await _orderService.GetOrdersByUserNameAsync(userName),
        };
        return Ok(purchase);
    }
}
