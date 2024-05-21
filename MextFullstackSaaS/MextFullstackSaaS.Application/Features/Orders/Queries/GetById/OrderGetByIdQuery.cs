using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQuery:IRequest<OrderGetByIdDto>
    {
        public Guid Id { get; set; }

        public OrderGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
