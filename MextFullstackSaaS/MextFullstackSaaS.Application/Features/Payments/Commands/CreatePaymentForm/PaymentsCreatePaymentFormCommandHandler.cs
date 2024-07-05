using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Payments;
using MextFullstackSaaS.Application.Features.Users.Queries.GetProfile;
using MextFullstackSaaS.Domain.ValueObjects;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentsCreatePaymentFormCommandHandler:IRequestHandler<PaymentsCreatePaymentFormCommand, ResponseDto<PaymentsCreatePaymentFormDto>>
    {
        private readonly IPaymentService _paymentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public PaymentsCreatePaymentFormCommandHandler(IPaymentService paymentService, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _paymentService = paymentService;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<ResponseDto<PaymentsCreatePaymentFormDto>> Handle(PaymentsCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _identityService.GetProfileAsync(cancellationToken);

           var paymentDetail = userProfile.MapToPaymentDetail();

            var userRequest = new PaymentsCreateCheckoutFormRequest(paymentDetail, request.Credits);

            var response = await _paymentService.CreateCheckoutFormAsync(userRequest, cancellationToken);

            return new ResponseDto<PaymentsCreatePaymentFormDto>();
        }
    }
}
