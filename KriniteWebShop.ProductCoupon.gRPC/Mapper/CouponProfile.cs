using AutoMapper;
using KriniteWebShop.ProductCoupon.gRPC.Entities;
using KriniteWebShop.ProductCoupon.gRPC.Protos;

namespace KriniteWebShop.ProductCoupon.gRPC.Mapper;

public class CouponProfile : Profile
{
    public CouponProfile() {
        CreateMap<Coupon, CouponModel>().ReverseMap();
        CreateMap<RestCoupon, CouponModel>().ReverseMap();
    }
}
