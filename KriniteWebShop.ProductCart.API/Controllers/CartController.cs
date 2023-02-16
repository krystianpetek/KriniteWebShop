using KriniteWebShop.ProductCart.API.Entities;
using KriniteWebShop.ProductCart.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using KriniteWebShop.ProductCart.API.GrpcServices;
using KriniteWebShop.ProductCoupon.gRPC.Protos;
using KriniteWebShop.EventBus.Events;
using AutoMapper;
using MassTransit;
using KriniteWebShop.ProductCart.API.Mappings;
using Microsoft.AspNetCore.Http;

namespace KriniteWebShop.ProductCart.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;
    private readonly CouponGrpcService _couponGrpcService;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<CartController> _logger;

    public CartController(
        ICartRepository cartRepository,
        CouponGrpcService couponGrpcService,
        IMapper mapper,
        IPublishEndpoint publishEndpoint,
        ILogger<CartController> logger)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _couponGrpcService = couponGrpcService ?? throw new ArgumentNullException(nameof(couponGrpcService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("{userName}", Name = "GetCart")]
    [Consumes(typeof(string), "text/plain")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetCart(string userName)
    {
        _logger.LogInformation($"Invoked method {nameof(GetCart)} for userName: {userName} in {nameof(CartController)}");

        ShoppingCart cart = await _cartRepository.GetCart(userName);
        return Ok(cart);
    }

    [HttpPost("Checkout", Name = "CartCheckout")]
    [Consumes(typeof(CartCheckout), "application/json")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CartCheckout(CartCheckout cartCheckout)
    {
        _logger.LogInformation($"Invoked method {nameof(CartCheckout)} for userName: {cartCheckout.UserName} in {nameof(CartController)}");

        ShoppingCart cart = await _cartRepository.GetCart(cartCheckout.UserName);
        if (cart?.TotalPrice == 0)
        {
            _logger.LogError($"Cart for userName {cartCheckout.UserName} doesn't exists.");
            return BadRequest($"Cart for userName {cartCheckout.UserName} doesn't exists.");
        }
        //CartCheckoutEvent cartCheckoutEvent = _mapper.Map<CartCheckout, CartCheckoutEvent>(cartCheckout);
        CartCheckoutEvent cartCheckoutEvent = cartCheckout.MapToCartCheckoutEvent();
        cartCheckoutEvent.TotalPrice = cart.TotalPrice;

        Task publish    = _publishEndpoint.Publish(cartCheckoutEvent);
        Task clearCache = _cartRepository.DeleteCart(cartCheckout.UserName);

        await Task.WhenAll(publish, clearCache);
        return Accepted();
    }

    [HttpPut("{userName}")]
    [Consumes(typeof(RestShoppingCart), "application/json")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(string userName, RestShoppingCart restShoppingCart)
    {
        _logger.LogInformation($"Invoked method {nameof(UpdateCart)} for userName: {userName} in {nameof(CartController)}");

        if (string.IsNullOrWhiteSpace(userName))
        {
            _logger.LogError($"Cart for userName {userName} doesn't exists");
            return BadRequest();
        }

        foreach (ShoppingCartItem shoppingCartItem in restShoppingCart.Items)
        {
            string productName = shoppingCartItem.ProductName;
            CouponModel couponModel = await _couponGrpcService.GetCoupon(productName);
            shoppingCartItem.Price -= couponModel.Amount;
        }

        ShoppingCart shoppingCart = restShoppingCart.MapToShoppingCart(userName);
        shoppingCart = await _cartRepository.UpdateCart(shoppingCart);

        return Ok(shoppingCart);
    }

    [HttpDelete("{userName}", Name = "DeleteCart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCart(string userName)
    {
        _logger.LogInformation($"Invoked method {nameof(DeleteCart)} for userName: {userName} in {nameof(CartController)}");

        await _cartRepository.DeleteCart(userName);
        return Ok();
    }
}
