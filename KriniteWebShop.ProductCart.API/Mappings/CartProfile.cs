using AutoMapper;
using KriniteWebShop.EventBus.Events;
using KriniteWebShop.ProductCart.API.Entities;

namespace KriniteWebShop.ProductCart.API.Mappings;

public class CartProfile : Profile
{
    public CartProfile() {
        CreateMap<CartCheckout, CartCheckoutEvent>().ReverseMap();
    }
}
