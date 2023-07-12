using KriniteWebShop.Coupon.gRPC.Entities;

namespace KriniteWebShop.Coupon.gRPC.Repositories;

public interface ICouponRepository
{
	Task<Entities.CouponEntity> GetCoupon(string productName);
	Task<bool> CreateCoupon(RestCoupon coupon);
	Task<bool> UpdateCoupon(RestCoupon coupon);
	Task<bool> DeleteCoupon(string productName);
}
