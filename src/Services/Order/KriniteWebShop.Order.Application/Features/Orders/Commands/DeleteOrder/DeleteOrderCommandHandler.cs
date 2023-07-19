using KriniteWebShop.Order.Application.Exceptions;
using KriniteWebShop.Order.Domain.Entities;
using KriniteWebShop.Order.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.Order.Application.Features.Orders.Commands.DeleteOrder;
internal class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
	private readonly IOrderRepository _orderRepository;
	private readonly ILogger<DeleteOrderCommandHandler> _logger;

	public DeleteOrderCommandHandler(
		IOrderRepository orderRepository,
		ILogger<DeleteOrderCommandHandler> logger)
	{
		_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
	{
		OrderEntity orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
		if (orderToDelete == default)
		{
			_logger.LogError($"Order with ID: {request.Id} not exists in database.");
			throw new NotFoundException(nameof(Order), request.Id);
		}

		await _orderRepository.DeleteAsync(orderToDelete);
		_logger.LogInformation($"Order with ID: {orderToDelete.Id} is successfully deleted.");

		return Unit.Value;
	}
}
