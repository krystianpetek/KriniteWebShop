using AutoMapper;
using KriniteWebShop.Coupon.gRPC.Entities;
using KriniteWebShop.Coupon.gRPC.Protos;

namespace KriniteWebShop.Coupon.gRPC.Mapper;

public class CouponProfile : Profile
{
	public CouponProfile()
	{
		CreateMap<CouponEntity, CouponModel>().ReverseMap();
		CreateMap<RestCoupon, CouponModel>().ReverseMap();
	}
}
