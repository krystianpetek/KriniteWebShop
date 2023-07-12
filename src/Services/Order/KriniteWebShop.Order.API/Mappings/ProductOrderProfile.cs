using AutoMapper;
using KriniteWebShop.EventBus.Events;
using KriniteWebShop.Order.Application.Features.Orders.Commands.CheckoutOrder;

namespace KriniteWebShop.Order.API.Mappings;

public class ProductOrderProfile : Profile
{
	public ProductOrderProfile()
	{
		CreateMap<CheckoutOrderCommand, CartCheckoutEvent>().ReverseMap();
	}
}
