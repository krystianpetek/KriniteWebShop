using AutoMapper;
using KriniteWebShop.Order.Application.Features.Orders.Commands.CheckoutOrder;
using KriniteWebShop.Order.Application.Features.Orders.Commands.DeleteOrder;
using KriniteWebShop.Order.Application.Features.Orders.Commands.UpdateOrder;
using KriniteWebShop.Order.Application.Features.Orders.Queries.GetOrdersList;
using KriniteWebShop.Order.Domain.Entities;

namespace KriniteWebShop.Order.Application.Mappings;
public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<OrderEntity, GetOrdersListQueryModel>().ReverseMap();

		CreateMap<OrderEntity, CheckoutOrderCommand>().ReverseMap();

		CreateMap<OrderEntity, UpdateOrderCommand>().ReverseMap();

		CreateMap<OrderEntity, DeleteOrderCommand>().ReverseMap();
	}
}
