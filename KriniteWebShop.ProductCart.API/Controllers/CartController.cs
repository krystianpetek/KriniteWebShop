using KriniteWebShop.ProductCart.API.Entities;
using KriniteWebShop.ProductCart.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.ProductCart.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
    }

    [HttpGet("{userName}", Name = "GetCart")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetCart(string userName)
    {
        var cart = await _cartRepository.GetCart(userName);
        return Ok(cart ?? new ShoppingCart(userName));
    }

    [HttpPut]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart shoppingCart)
    {
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
