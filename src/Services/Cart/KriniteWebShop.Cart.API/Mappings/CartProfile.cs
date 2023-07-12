using AutoMapper;
using KriniteWebShop.Cart.API.Entities;
using KriniteWebShop.EventBus.Events;

namespace KriniteWebShop.Cart.API.Mappings;

public class CartProfile : Profile
{
	public CartProfile()
	{
		CreateMap<CartCheckout, CartCheckoutEvent>().ReverseMap();
	}
}
