using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler: IRequestHandler<OrderAddCommand, Guid>
    {
        public Task<Guid> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Guid.NewGuid());
        }
    }
}
