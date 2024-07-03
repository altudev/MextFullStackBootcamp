using MediatR;
using MextFullstackSaaS.Application.Features.Users.Queries.GetProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediatr;

        public UsersController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync(CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new UserGetProfileQuery(), cancellationToken));
        }
    }
}
