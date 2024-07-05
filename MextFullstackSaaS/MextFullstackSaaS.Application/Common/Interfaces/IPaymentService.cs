using MextFullstackSaaS.Application.Common.Models.Payments;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<object> CreateCheckoutFormAsync(PaymentsCreateCheckoutFormRequest userRequest, CancellationToken cancellationToken);
    }
}
