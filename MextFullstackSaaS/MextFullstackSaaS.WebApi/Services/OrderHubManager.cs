using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.WebApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MextFullstackSaaS.WebApi.Services;

public class OrderHubManager:IOrderHubService
{
    private readonly IHubContext<OrderHub> _hubContext;

    public OrderHubManager(IHubContext<OrderHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task NewOrderAddedAsync(List<string> urls, CancellationToken cancellationToken)
    {
        return _hubContext.Clients.All.SendAsync("NewOrderAdded", urls, cancellationToken);
    }
}