using KriniteWebShop.Coupon.API.Entities;

namespace KriniteWebShop.Coupon.API.Repositories;

public interface ICouponRepository
{
	Task<Entities.Coupon> GetCoupon(string productName);
	Task<bool> CreateCoupon(RestCoupon coupon);
	Task<bool> UpdateCoupon(RestCoupon coupon);
	Task<bool> DeleteCoupon(string productName);
}
