using MextFullstackSaaS.Application.Common.Models.Payments;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        PaymentsCreateCheckoutFormResponse CreateCheckoutForm(PaymentsCreateCheckoutFormRequest userRequest);
    }
}
