using KriniteWebShop.ProductCoupon.API.Entities;
using KriniteWebShop.ProductCoupon.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.ProductCoupon.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CouponController : ControllerBase
{
    private readonly ICouponRepository _couponRepository;

    public CouponController(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
    }

    [HttpGet("{productName}", Name = "GetCoupon")]
    [ProducesResponseType(typeof(Coupon), StatusCodes.Status200OK)]
    public async Task<ActionResult<Coupon>> GetCoupon(string productName)
    {
        Coupon coupon = await _couponRepository.GetCoupon(productName);
        return Ok(coupon);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Coupon), StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> CreateCoupon(RestCoupon coupon)
    {
        await _couponRepository.CreateCoupon(coupon);
        return CreatedAtAction("GetCoupon", new { productName = coupon.ProductName }, coupon);
    }

    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> UpdateCoupon(Coupon coupon)
    {
        bool result = await _couponRepository.UpdateCoupon(coupon);
        return Ok(result);
    }

    [HttpDelete("{productName}", Name = "DeleteCoupon")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> DeleteCoupon(string productName)
    {
        bool result = await _couponRepository.DeleteCoupon(productName);
        return Ok(result);
    }

}
