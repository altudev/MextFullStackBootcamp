using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler:IRequestHandler<OrderGetAllQuery,List<OrderGetAllDto>>
    {
        public Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<OrderGetAllDto>());
        }
    }
}
