using MediatR;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.UpdateOrder;
public class DeleteOrderCommand : IRequest
{
    public Guid Id { get; set; }
}
