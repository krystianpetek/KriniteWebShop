using KriniteWebShop.Coupon.gRPC.Protos;

namespace KriniteWebShop.Cart.API.GrpcServices;

public class CouponGrpcService
{
	private readonly CouponProtoService.CouponProtoServiceClient _couponGrpcServiceClient;

	public CouponGrpcService(CouponProtoService.CouponProtoServiceClient couponGrpcServiceClient)
	{
		_couponGrpcServiceClient = couponGrpcServiceClient ?? throw new ArgumentNullException(nameof(couponGrpcServiceClient));
	}

	public async Task<CouponModel> GetCoupon(string productName)
	{
		GetCouponRequest getCouponRequest = new GetCouponRequest { ProductName = productName };
		return await _couponGrpcServiceClient.GetCouponAsync(getCouponRequest);
	}
}
