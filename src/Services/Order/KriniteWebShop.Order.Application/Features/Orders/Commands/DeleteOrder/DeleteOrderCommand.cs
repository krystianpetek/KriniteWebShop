using MediatR;

namespace KriniteWebShop.Order.Application.Features.Orders.Commands.DeleteOrder;
public class DeleteOrderCommand : IRequest
{
	public Guid Id { get; set; }
}
