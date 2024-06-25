using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAllCommunity;

public class OrderGetAllCommunityQueryHandler:IRequestHandler<OrderGetAllCommunityQuery,List<string>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public OrderGetAllCommunityQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<string>> Handle(OrderGetAllCommunityQuery request, CancellationToken cancellationToken)
    {
        var urlsLists = await _applicationDbContext
            .Orders
            .AsNoTracking()
            .Select(x=>x.Urls)
            .ToListAsync(cancellationToken);

        var urls = urlsLists
            .SelectMany(x => x)
            .ToList();
        
        return urls;
    }
}