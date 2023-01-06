using KriniteWebShop.ProductCart.API.Entities;
using KriniteWebShop.ProductCart.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using KriniteWebShop.ProductCart.API.GrpcServices;
using KriniteWebShop.ProductCoupon.gRPC.Protos;

namespace KriniteWebShop.ProductCart.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;
    private readonly CouponGrpcService _couponGrpcService;

    public CartController(ICartRepository cartRepository, CouponGrpcService couponGrpcService)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _couponGrpcService = couponGrpcService ?? throw new ArgumentNullException(nameof(couponGrpcService));
    }

    [HttpGet("{userName}", Name = "GetCart")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetCart(string userName)
    {
        var cart = await _cartRepository.GetCart(userName);
        return Ok(cart ?? new ShoppingCart(userName));
    }

    [HttpPut("{userName}")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(string userName, ShoppingCart shoppingCart)
    {
        foreach (ShoppingCartItem shoppingCartItem in shoppingCart.Items)
        {
            string productName = shoppingCartItem.ProductName;
            CouponModel couponModel = await _couponGrpcService.GetCoupon(productName);
            shoppingCartItem.Price -= couponModel.Amount;
         }
        return Ok(await _cartRepository.UpdateCart(shoppingCart));
    }

    [HttpDelete("{userName}", Name = "DeleteCart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCart(string userName)
    {
        await _cartRepository.DeleteCart(userName);
        return Ok();
    }
}
