using MediatR;
using MextFullstackSaaS.Application.Common.Helpers;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQueryHandler : IRequestHandler<OrderGetByIdQuery, OrderGetByIdDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public OrderGetByIdQueryHandler(IApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task<OrderGetByIdDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
        {
            OrderGetByIdDto order;

            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrderGetByIdKey(request.Id), out order))
                return order;

            var normalOrder = await _dbContext
                .Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            order = OrderGetByIdDto.MapFromOrder(normalOrder);

            _memoryCache.Set(MemoryCacheHelper.GetOrderGetByIdKey(request.Id), order,
                MemoryCacheHelper.GetMemoryCacheEntryOptions());

            return order;
        }
    }
}