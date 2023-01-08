using MediatR;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.DeleteOrder;
public class DeleteOrderCommand : IRequest
{
    public Guid Id { get; set; }
}
