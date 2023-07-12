using AutoMapper;
using KriniteWebShop.Order.Application.Contracts.Persistance;
using KriniteWebShop.Order.Domain.Entities;
using MediatR;

namespace KriniteWebShop.Order.Application.Features.Orders.Queries.GetOrdersList;
public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<GetOrdersListQueryModel>>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IMapper _mapper;

	public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
	{
		_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	public async Task<List<GetOrdersListQueryModel>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
	{
		IEnumerable<OrderEntity> orderListResponse = await _orderRepository.GetOrdersByUserName(request.UserName);
		List<GetOrdersListQueryModel> mappedOrderListResponse = _mapper.Map<IEnumerable<OrderEntity>, List<GetOrdersListQueryModel>>(orderListResponse);
		return mappedOrderListResponse;
	}
}
