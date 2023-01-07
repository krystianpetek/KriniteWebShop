using AutoMapper;
using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Domain.Entities;
using MediatR;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Queries.GetOrdersList;
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
        IEnumerable<Order> orderListResponse = await _orderRepository.GetOrdersByUserName(request.UserName);
        List<GetOrdersListQueryModel> mappedOrderListResponse = _mapper.Map<IEnumerable<Order>, List<GetOrdersListQueryModel>>(orderListResponse);
        return mappedOrderListResponse;
    }
}
