using MextFullstackSaaS.Domain.ValueObjects;

namespace MextFullstackSaaS.Application.Common.Models.Payments
{
    public class PaymentsCreateCheckoutFormRequest
    {
        public UserPaymentDetail PaymentDetail { get; set; }
        public int Credits { get; set; }

        public PaymentsCreateCheckoutFormRequest(UserPaymentDetail paymentDetail, int credits)
        {
            PaymentDetail = paymentDetail;
            Credits = credits;
        }

        public PaymentsCreateCheckoutFormRequest()
        {
            
        }
    }
}
