using KriniteWebShop.ProductCoupon.gRPC.Entities;
using KriniteWebShop.ProductCoupon.gRPC.Protos;

namespace KriniteWebShop.ProductCoupon.gRPC.Mapper;

public static class CouponMapper
{
    public static CouponModel MapToCouponModel(this Coupon coupon)
    {
        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount,
        };
    }

    public static CouponModel MapToCouponModel(this RestCoupon coupon)
    {
        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount,
        };
    }

    public static Coupon MapToCoupon(this CouponModel couponModel)
    {
        return new Coupon
        {
            Id = couponModel.Id,
            ProductName = couponModel.ProductName,
            Description = couponModel.Description,
            Amount = couponModel.Amount,
        };
    }

    public static RestCoupon MapToRestCoupon(this CouponModel couponModel)
    {
        return new RestCoupon
        {
            Id = couponModel.Id,
            ProductName = couponModel.ProductName,
            Description = couponModel.Description,
            Amount = couponModel.Amount,
        };
    }
}
