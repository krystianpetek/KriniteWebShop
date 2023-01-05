using KriniteWebShop.ProductCoupon.gRPC.Entities;

namespace KriniteWebShop.ProductCoupon.gRPC.Repositories;

public interface ICouponRepository
{
    Task<Coupon> GetCoupon(string productName);
    Task<bool> CreateCoupon(RestCoupon coupon);
    Task<bool> UpdateCoupon(Coupon coupon);
    Task<bool> DeleteCoupon(string productName);
}
