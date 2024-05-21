using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }

        public OrderDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
