using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Application.Exceptions;
using KriniteWebShop.ProductOrder.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.DeleteOrder;
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
        Order orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
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
