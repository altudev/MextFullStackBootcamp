using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestCountersController : ControllerBase
    {
        private readonly RequestCounterManager _requestCounterManager;

        public RequestCountersController(RequestCounterManager requestCounterManager)
        {
            _requestCounterManager = requestCounterManager;
        }

        [HttpGet]
        public IActionResult GetTotalCount()
        {
            return Ok(_requestCounterManager.GetTotalCount());
        }
    }
}
