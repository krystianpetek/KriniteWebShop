using KriniteWebShop.ProductCoupon.API.Entities;

namespace KriniteWebShop.ProductCoupon.API.Repositories;

public interface ICouponRepository
{
    Task<Coupon> GetCoupon(string productName);
    Task<bool> CreateCoupon(RestCoupon coupon);
    Task<bool> UpdateCoupon(RestCoupon coupon);
    Task<bool> DeleteCoupon(string productName);
}
