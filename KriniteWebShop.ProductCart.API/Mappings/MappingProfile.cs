using AutoMapper;
using KriniteWebShop.EventBus.Events;
using KriniteWebShop.ProductCart.API.Entities;

namespace KriniteWebShop.ProductCart.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<CartCheckout, CartCheckoutEvent>().ReverseMap();
    }
}
