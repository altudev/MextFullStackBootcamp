using MediatR;
using MextFullstackSaaS.Application.Features.Orders.Queries.GetAllCommunity;
using Microsoft.AspNetCore.SignalR;

namespace MextFullstackSaaS.WebApi.Hubs;

public class OrderHub:Hub
{
    private readonly ISender _mediatr;

    public OrderHub(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task NewOrderAddedAsync()
    {
        
    }

    public Task<List<string>> GetAllCommunityAsync()
    {
        return _mediatr.Send(new OrderGetAllCommunityQuery());
    }
}