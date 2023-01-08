using AutoMapper;
using KriniteWebShop.ProductOrder.Application.Contracts.Infrastructure;
using KriniteWebShop.ProductOrder.Application.Contracts.Persistance;
using KriniteWebShop.ProductOrder.Application.Models;
using KriniteWebShop.ProductOrder.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.CheckoutOrder;
public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    //private readonly IEmailService _emailService;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public CheckoutOrderCommandHandler(
        IOrderRepository orderRepository,
        IMapper mapper,
        //IEmailService emailService,
        ILogger<CheckoutOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //_emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        Order orderEntity = _mapper.Map<CheckoutOrderCommand, Order>(request); 
        Order newOrder = await _orderRepository.AddAsync(orderEntity);

        _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

        await SendMail(newOrder);
        return newOrder.Id;
    }

    private async Task SendMail(Order order)
    {
        EmailModel email = new EmailModel
        {
            To = "krystianpetek2@gmail.com",
            Body = $"Order {order.Id} was created.",
            Subject = $"Order was created successfully."
        };

        try
        {
            _logger.LogWarning("Mock sending email, but not implemented");
            //await _emailService.SendMail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
        }
    }
}
