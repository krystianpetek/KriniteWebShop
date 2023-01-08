using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.CheckoutOrder;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.DeleteOrder;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.UpdateOrder;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Queries.GetOrdersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KriniteWebShop.ProductOrder.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{userName}", Name = "GetOrder")]
    [ProducesResponseType(typeof(IEnumerable<GetOrdersListQueryModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetOrdersListQueryModel>>> GetOrdersByUserName(string userName)
    {
        GetOrdersListQuery query = new GetOrdersListQuery(userName);

        IEnumerable<GetOrdersListQueryModel> orders = await _mediator.Send<IEnumerable<GetOrdersListQueryModel>>(query);

        return Ok(orders);
    }

    [HttpPost(Name = "CheckoutOrder")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<ActionResult<Guid>> CheckoutOrder(CheckoutOrderCommand checkoutOrderCommand)
    {
        var orderId = await _mediator.Send<Guid>(checkoutOrderCommand);
        return Created($"{orderId}", null);
    }

    [HttpPut(Name = "UpdateOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommand updateOrderCommand)
    {
        await _mediator.Send<Unit>(updateOrderCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteOrder")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        DeleteOrderCommand command = new DeleteOrderCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }
}
