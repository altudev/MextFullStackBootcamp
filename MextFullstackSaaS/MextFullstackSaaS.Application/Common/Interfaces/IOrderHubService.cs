namespace MextFullstackSaaS.Application.Common.Interfaces;

public interface IOrderHubService
{
    Task NewOrderAddedAsync(List<string> urls, CancellationToken cancellationToken);
}