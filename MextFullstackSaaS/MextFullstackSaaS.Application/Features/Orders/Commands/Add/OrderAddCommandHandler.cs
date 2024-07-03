using MediatR;
using MextFullstackSaaS.Application.Common.Helpers;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.OpenAI;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAll;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler: IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOpenAIService _openAiService;
        private readonly IMemoryCache _memoryCache;
        private readonly IOrderHubService _orderHubService;
        private readonly IObjectStorageService _objectStorageService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService, IOpenAIService openAiService, IMemoryCache memoryCache, IOrderHubService orderHubService, IObjectStorageService objectStorageService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAiService = openAiService;
            _memoryCache = memoryCache;
            _orderHubService = orderHubService;
            _objectStorageService = objectStorageService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
           var order = OrderAddCommand.MapToOrder(request,_currentUserService.UserId);

           var base64Images =
               await _openAiService.DallECreateIconAsync(DallECreateIconRequestDto.MapFromOrderAddCommand(request),
                   cancellationToken);

            order.Urls = await _objectStorageService.UploadImagesAsync(base64Images, cancellationToken);

            _dbContext.Orders.Add(order);

            await DecreaseCreditsAsync(cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            if (_memoryCache.TryGetValue(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),out List<OrderGetAllDto> orders))
            {
                orders.Add(OrderGetAllDto.FromOrder(order));

                _memoryCache.Set(MemoryCacheHelper.GetOrdersGetAllKey(_currentUserService.UserId),orders,MemoryCacheHelper.GetMemoryCacheEntryOptions());
            }

            await _orderHubService.NewOrderAddedAsync(order.Urls,cancellationToken);

            return new ResponseDto<Guid>(order.Id,"Your order completed successfully.");
        }

        private async Task DecreaseCreditsAsync(CancellationToken cancellationToken)
        {
            var userBalance = await _dbContext.
                UserBalances
                .FirstOrDefaultAsync(x => x.UserId == _currentUserService.UserId, cancellationToken);

            userBalance.Credits--;
            userBalance.ModifiedByUserId = _currentUserService.UserId.ToString();
            userBalance.ModifiedOn = DateTimeOffset.UtcNow;

            var history = new UserBalanceHistory()
            {
                Id = Guid.NewGuid(),
                UserBalanceId = userBalance.Id,
                CreatedByUserId = _currentUserService.UserId.ToString(),
                CreatedOn = DateTimeOffset.UtcNow,
                Amount = 1,
                PreviousCredits = userBalance.Credits + 1,
                CurrentCredits = userBalance.Credits,
                Type = UserBalanceHistoryType.DeductCredits
            };

            // userBalance.Histories.Add(history);

            _dbContext.UserBalances.Update(userBalance);

            _dbContext.UserBalanceHistories.Add(history);
        }
    }
}
