using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler:IRequestHandler<OrderGetAllQuery,List<OrderGetAllDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderGetAllQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
        {
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
           return _applicationDbContext
                .Orders
                .Where(x=>x.UserId == _currentUserService.UserId)
                .Select(o => OrderGetAllDto.FromOrder(o))
                .ToListAsync(cancellationToken);
        }
    }
}
