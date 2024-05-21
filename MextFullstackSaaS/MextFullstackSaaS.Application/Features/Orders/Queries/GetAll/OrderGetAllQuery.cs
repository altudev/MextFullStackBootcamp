using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQuery:IRequest<List<OrderGetAllDto>>
    {
    }
}
