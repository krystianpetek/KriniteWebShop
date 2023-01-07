﻿using MediatR;

namespace KriniteWebShop.ProductOrder.Application.Features.Orders.Queries.GetOrdersList;
 
public class GetOrdersListQuery : IRequest<List<GetOrdersListQueryModel>>
{
    public string UserName { get; set; }

    public GetOrdersListQuery(string userName)
    {
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
    }
}
