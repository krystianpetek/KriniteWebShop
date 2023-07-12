using KriniteWebShop.Coupon.gRPC.Entities;
using KriniteWebShop.Coupon.gRPC.Protos;

namespace KriniteWebShop.Coupon.gRPC.Mapper;

public static class CouponMapper
{
	public static CouponModel MapToCouponModel(this CouponEntity coupon)
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

	public static CouponEntity MapToCoupon(this CouponModel couponModel)
	{
		return new CouponEntity
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
