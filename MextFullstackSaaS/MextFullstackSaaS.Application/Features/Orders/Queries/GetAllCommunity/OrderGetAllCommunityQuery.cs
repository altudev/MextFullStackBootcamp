using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAllCommunity;

public class OrderGetAllCommunityQuery:IRequest<List<string>>
{
    public OrderGetAllCommunityQuery()
    {
        
    }
}