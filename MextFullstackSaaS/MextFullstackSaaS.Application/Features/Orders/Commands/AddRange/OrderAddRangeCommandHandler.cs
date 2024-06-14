using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.AddRange
{
    public class OrderAddRangeCommandHandler:IRequestHandler<OrderAddRangeCommand, ResponseDto<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderAddRangeCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<int>> Handle(OrderAddRangeCommand request, CancellationToken cancellationToken)
        {
            List<Order> orders = new List<Order>();

            for (int i = 0; i < request.OrderCount; i++)
            {
                var order= new Order
                {
                    Id = Guid.NewGuid(),
                    Description = "A smiley puffy cat.",
                    DesignType = DesignType.Flat,
                    Quantity = 1,
                    Shape = IconShape.Circle,
                    Size = IconSize.Large,
                    IconDescription = "A smiley puffy cat.",
                    Model = AIModelType.DallE3,
                    Urls = new List<string>(){ "https://www.google.com/" },
                    ColourCode = "Red",
                    UserId = _currentUserService.UserId,
                    CreatedOn = DateTimeOffset.UtcNow,
                    CreatedByUserId = _currentUserService.UserId.ToString(),
                };

                orders.Add(order);
            }

            _dbContext.Orders.AddRange(orders);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<int>(orders.Count,$"Totally {orders.Count} orders added.");
        }
    }
}
