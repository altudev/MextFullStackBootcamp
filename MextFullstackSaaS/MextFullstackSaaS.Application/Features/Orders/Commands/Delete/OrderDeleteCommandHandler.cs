using MediatR;
using MextFullstackSaaS.Application.Common.Helpers;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAll;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetById;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler:IRequestHandler<OrderDeleteCommand,ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly ICurrentUserService _currentUserService;

        public OrderDeleteCommandHandler(IApplicationDbContext dbContext, IMemoryCache memoryCache, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
           var order = await _dbContext
                .Orders
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrderGetByIdKey(request.Id), out OrderGetByIdDto orderGetByIdDto))
                _memoryCache.Remove(MemoryCacheHelper.GetOrderGetByIdKey(request.Id));

            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),
                    out List<OrderGetAllDto> orders))
            {
                orders = orders.Where(x => x.Id != request.Id).ToList();

                _memoryCache.Set(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId), orders,
                    MemoryCacheHelper.GetMemoryCacheEntryOptions());
            }

            return new ResponseDto<Guid>(order.Id, "Order deleted successfully.");
        }
    }
}
