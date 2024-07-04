namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<object> CreateCheckoutFormAsync(CancellationToken cancellationToken);
    }
}
