using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler:IRequestHandler<OrderDeleteCommand,Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderDeleteCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
           var order = await _dbContext
                .Orders
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id; // The selected order has been deleted successfully.
        }
    }
}
