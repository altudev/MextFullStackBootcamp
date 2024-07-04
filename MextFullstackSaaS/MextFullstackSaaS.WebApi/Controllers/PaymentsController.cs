using MediatR;
using MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ISender _mediator;

        public PaymentsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentFormAsync(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new PaymentsCreatePaymentFormCommand(), cancellationToken));
        }

        [HttpPost("payment-result")]
        public async Task<IActionResult> PaymentResultAsync([FromForm]string token, CancellationToken cancellationToken)
        {
            return Redirect($"http://localhost:5262/payment-success?token={token}");
        }


    }
}
