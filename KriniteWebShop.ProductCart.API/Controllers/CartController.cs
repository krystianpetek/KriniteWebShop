using KriniteWebShop.ProductCart.API.Entities;
using KriniteWebShop.ProductCart.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using KriniteWebShop.ProductCart.API.GrpcServices;
using KriniteWebShop.ProductCoupon.gRPC.Protos;
using KriniteWebShop.EventBus.Events;
using AutoMapper;
using MassTransit;

namespace KriniteWebShop.ProductCart.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;
    private readonly CouponGrpcService _couponGrpcService;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public CartController(
        ICartRepository cartRepository,
        CouponGrpcService couponGrpcService,
        IMapper mapper,
        IPublishEndpoint publishEndpoint)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _couponGrpcService = couponGrpcService ?? throw new ArgumentNullException(nameof(couponGrpcService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }

    [HttpGet("{userName}", Name = "GetCart")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetCart(string userName)
    {
        ShoppingCart cart = await _cartRepository.GetCart(userName);
        return Ok(cart ?? new ShoppingCart(userName));
    }

    [HttpPost("Checkout", Name = "CartCheckout")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<ActionResult> CartCheckout(CartCheckout cartCheckout)
    {
        ShoppingCart cart = await _cartRepository.GetCart(cartCheckout?.UserName);
        if (cart == default)
            return BadRequest();

        CartCheckoutEvent cartCheckoutEvent = _mapper.Map<CartCheckout, CartCheckoutEvent>(cartCheckout);
        cartCheckoutEvent.TotalPrice = cart.TotalPrice;

        Task publish = _publishEndpoint.Publish(cartCheckoutEvent);
        Task clearCache = _cartRepository.DeleteCart(cartCheckout.UserName);

        await Task.WhenAll(publish, clearCache);
        return Accepted();
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
