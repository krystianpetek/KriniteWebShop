using AutoMapper;
using KriniteWebShop.EventBus.Events;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.CheckoutOrder;
using MassTransit;
using MediatR;

namespace KriniteWebShop.ProductOrder.API.EventBusConsumer;

public class CartCheckoutConsumer : IConsumer<CartCheckoutEvent>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger<CartCheckoutConsumer> _logger;

    public CartCheckoutConsumer(
        IMapper mapper,
        IMediator mediator,
        ILogger<CartCheckoutConsumer> logger
        )
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
    {
        CheckoutOrderCommand command = _mapper.Map<CartCheckoutEvent, CheckoutOrderCommand>(context.Message);
        Guid result = await _mediator.Send(command);

        _logger.LogInformation($"CartCheckoutEvent consumed successfully. Created order with ID: {result}");
    }
}
