using AutoMapper;
using KriniteWebShop.Order.Application.Contracts.Persistance;
using KriniteWebShop.Order.Application.Exceptions;
using KriniteWebShop.Order.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.Order.Application.Features.Orders.Commands.UpdateOrder;
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IMapper _mapper;
	private readonly ILogger<UpdateOrderCommandHandler> _logger;

	public UpdateOrderCommandHandler(
		IOrderRepository orderRepository,
		IMapper mapper,
		ILogger<UpdateOrderCommandHandler> logger)
	{
		_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
	{
		OrderEntity orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
		if (orderToUpdate == default)
		{
			_logger.LogError($"Order with ID: {request.Id} not exists in database.");
			throw new NotFoundException(nameof(Order), request.Id);
		}
		orderToUpdate = _mapper.Map<UpdateOrderCommand, OrderEntity>(request);

		await _orderRepository.UpdateAsync(orderToUpdate);
		_logger.LogInformation($"Order with ID: {orderToUpdate.Id} is successfully updated.");

		return Unit.Value;
	}
}
