using Microsoft.AspNetCore.Mvc;
using KriniteWebShop.Coupon.API.Repositories;
using KriniteWebShop.Coupon.API.Entities;

namespace KriniteWebShop.Coupon.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CouponController : ControllerBase
{
	private readonly ICouponRepository _couponRepository;
	private readonly ILogger<CouponController> _logger;

	public CouponController(ICouponRepository couponRepository, ILogger<CouponController> logger)
	{
		_couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	[HttpGet("{productName}", Name = "GetCoupon")]
	[Consumes(typeof(string), "text/plain")]
	[ProducesResponseType(typeof(Entities.Coupon), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<Entities.Coupon>> GetCoupon(string productName)
	{
		_logger.LogInformation($"Invoked method {nameof(GetCoupon)} for product: {productName} in {nameof(CouponController)}");

		Entities.Coupon coupon = await _couponRepository.GetCoupon(productName);
		if (coupon == null)
			return NotFound();

		return Ok(coupon);
	}

	[HttpPost]
	[Consumes(typeof(RestCoupon), "application/json")]
	[ProducesResponseType(typeof(Entities.Coupon), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesDefaultResponseType]
	public async Task<ActionResult<bool>> CreateCoupon(RestCoupon coupon)
	{
		_logger.LogInformation($"Invoked method {nameof(CreateCoupon)} for product: {coupon.ProductName} in {nameof(CouponController)}");

		if (coupon == null)
			return NotFound();

		await _couponRepository.CreateCoupon(coupon);
		return CreatedAtAction("GetCoupon", new { productName = coupon.ProductName }, coupon);
	}

	[HttpPut("{productName}")]
	[Consumes(typeof(string), "text/plain")]
	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesDefaultResponseType]
	public async Task<ActionResult<bool>> UpdateCoupon(string productName, RestCoupon coupon)
	{
		_logger.LogInformation($"Invoked method {nameof(UpdateCoupon)} for product: {coupon.ProductName} in {nameof(CouponController)}");

		if (string.IsNullOrWhiteSpace(productName))
			return NotFound();

		bool result = await _couponRepository.UpdateCoupon(coupon);
		return Ok(result);
	}

	[HttpDelete("{productName}", Name = "DeleteCoupon")]
	[Consumes(typeof(string), "text/plain")]
	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesDefaultResponseType]
	public async Task<ActionResult<bool>> DeleteCoupon(string productName)
	{
		_logger.LogInformation($"Invoked method {nameof(DeleteCoupon)} for product: {productName} in {nameof(CouponController)}");

		if (string.IsNullOrWhiteSpace(productName))
			return NotFound();

		bool result = await _couponRepository.DeleteCoupon(productName);
		return Ok(result);
	}

}
