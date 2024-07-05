using MediatR;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommand:IRequest<ResponseDto<PaymentsCreatePaymentFormDto>>
    {
        public int Credits { get; set; }
    }
}
