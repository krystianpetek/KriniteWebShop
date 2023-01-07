using AutoMapper;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.CheckoutOrder;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Commands.UpdateOrder;
using KriniteWebShop.ProductOrder.Application.Features.Orders.Queries.GetOrdersList;
using KriniteWebShop.ProductOrder.Domain.Entities;

namespace KriniteWebShop.ProductOrder.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, GetOrdersListQueryModel>().ReverseMap();

        CreateMap<Order, CheckoutOrderCommand>().ReverseMap();

        CreateMap<Order, UpdateOrderCommand>().ReverseMap();

        CreateMap<Order, DeleteOrderCommand>().ReverseMap();
    }
}
