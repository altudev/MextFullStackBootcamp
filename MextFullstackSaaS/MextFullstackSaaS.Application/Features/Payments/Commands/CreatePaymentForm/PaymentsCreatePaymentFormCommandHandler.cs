using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommandHandler:IRequestHandler<PaymentsCreatePaymentFormCommand, object>
    {
        private readonly IPaymentService _paymentService;

        public PaymentsCreatePaymentFormCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Task<object> Handle(PaymentsCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            return _paymentService.CreateCheckoutFormAsync(cancellationToken);
        }
    }
}
