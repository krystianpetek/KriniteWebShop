using AutoMapper;
using KriniteWebShop.EventBus.Events;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.CheckoutOrder;

namespace KriniteWebShop.ProductOrder.API.Mappings;

public class ProductOrderProfile : Profile
{
    public ProductOrderProfile() {
    CreateMap<CheckoutOrderCommand, CartCheckoutEvent>().ReverseMap();
    }
}
