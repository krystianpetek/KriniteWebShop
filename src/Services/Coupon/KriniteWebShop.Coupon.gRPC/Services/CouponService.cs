using AutoMapper;
using Grpc.Core;
using KriniteWebShop.Coupon.gRPC.Entities;
using KriniteWebShop.Coupon.gRPC.Mapper;
using KriniteWebShop.Coupon.gRPC.Repositories;
using KriniteWebShop.Coupon.gRPC.Protos;

namespace KriniteWebShop.Coupon.gRPC.Services;
public class CouponService : CouponProtoService.CouponProtoServiceBase
{
	private readonly ICouponRepository _couponRepository;
	private readonly ILogger<CouponService> _logger;
	private readonly IMapper _mapper;

	public CouponService(ICouponRepository couponRepository, ILogger<CouponService> logger, IMapper mapper)
	{
		_couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	public override async Task<CouponModel> GetCoupon(GetCouponRequest request, ServerCallContext context)
	{
		_logger.LogInformation($"Invoked method {nameof(GetCoupon)} for product: {request.ProductName} in {nameof(CouponService)}");

		CouponEntity coupon = await _couponRepository.GetCoupon(request.ProductName);
		if (coupon == null)
			throw new RpcException(new Status(StatusCode.NotFound, $"Coupon with ProductName = {coupon?.ProductName} not found."));
		_logger.LogInformation($"Coupon is retrieved for ProductName: {coupon.ProductName}, Amount: {coupon.Amount}");

		//CouponModel couponModel = _mapper.Map<Coupon, CouponModel>(coupon);
		CouponModel couponModel = coupon.MapToCouponModel();
		return couponModel;
	}

	public override async Task<CouponModel> CreateCoupon(CreateCouponRequest request, ServerCallContext context)
	{
		_logger.LogInformation($"Invoked method {nameof(CreateCoupon)} for product: {request.Coupon.ProductName} in {nameof(CouponService)}");

		RestCoupon restCoupon = request.Coupon.MapToRestCoupon();

		bool result = await _couponRepository.CreateCoupon(restCoupon);
		if (!result)
			throw new RpcException(new Status(StatusCode.Cancelled, $"Adding coupon ProductName = {restCoupon.ProductName} was rejected."));

		_logger.LogInformation($"Coupon ProductName: {restCoupon.ProductName} was created succesfully.");

		CouponModel returnCouponModel = restCoupon.MapToCouponModel();
		return returnCouponModel;
	}

	public override async Task<DeleteCouponResponse> DeleteCoupon(DeleteCouponRequest request, ServerCallContext context)
	{
		_logger.LogInformation($"Invoked method {nameof(DeleteCoupon)} for product: {request.ProductName}  {nameof(CouponService)}");

		bool result = await _couponRepository.DeleteCoupon(request.ProductName);
		if (!result)
			throw new RpcException(new Status(StatusCode.Cancelled, $"Deleting coupon ProductName = {request.ProductName} was rejected."));

		_logger.LogInformation($"Coupon ProductName: {request.ProductName} was deleted succesfully.");

		DeleteCouponResponse deleteCouponResponse = new DeleteCouponResponse { Success = result };
		return deleteCouponResponse;
	}

	public override async Task<CouponModel> UpdateCoupon(UpdateCouponRequest request, ServerCallContext context)
	{
		_logger.LogInformation($"Invoked method {nameof(UpdateCoupon)} for product: {request.Coupon.ProductName} in {nameof(CouponService)}");

		RestCoupon coupon = request.Coupon.MapToRestCoupon();

		bool result = await _couponRepository.UpdateCoupon(coupon);
		if (!result)
			throw new RpcException(new Status(StatusCode.Cancelled, $"Updating coupon ProductName = {coupon.ProductName} was cancelled."));

		_logger.LogInformation($"Coupon ProductName: {coupon.ProductName} was updated succesfully.");

		CouponModel returnCouponModel = coupon.MapToCouponModel();
		return returnCouponModel;
	}
}
