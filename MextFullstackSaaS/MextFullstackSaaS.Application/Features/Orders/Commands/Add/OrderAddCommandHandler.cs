using MediatR;
using MextFullstackSaaS.Application.Common.Helpers;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.OpenAI;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAll;
using Microsoft.Extensions.Caching.Memory;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler: IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOpenAIService _openAiService;
        private readonly IMemoryCache _memoryCache;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService, IOpenAIService openAiService, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAiService = openAiService;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
           var order = OrderAddCommand.MapToOrder(request,_currentUserService.UserId);

           order.Urls =
               await _openAiService.DallECreateIconAsync(DallECreateIconRequestDto.MapFromOrderAddCommand(request),
                   cancellationToken);

            /* TODO: Make Request to the Gemine or Dall-e 3 */

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),out List<OrderGetAllDto> orders))
            {
                orders.Add(OrderGetAllDto.FromOrder(order));

                _memoryCache.Set(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),orders,MemoryCacheHelper.GetMemoryCacheEntryOptions());
            }

            return new ResponseDto<Guid>(order.Id,"Your order completed successfully.");
        }
    }
}
