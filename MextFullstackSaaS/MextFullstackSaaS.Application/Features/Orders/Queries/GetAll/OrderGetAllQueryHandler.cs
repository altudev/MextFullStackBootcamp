using MediatR;
using MextFullstackSaaS.Application.Common.Helpers;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;

        public OrderGetAllQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
            _memoryCache = memoryCache;
        }

        public async Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            List<OrderGetAllDto> orders;

            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId), out orders))
                return orders;

            orders = await _applicationDbContext
                 .Orders
                 .Where(x => x.UserId == _currentUserService.UserId)
                 .Select(o => OrderGetAllDto.FromOrder(o))
                 .ToListAsync(cancellationToken);

            _memoryCache.Set(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId), orders, MemoryCacheHelper.GetMemoryCacheEntryOptions());

            return orders;
        }
    }
}
