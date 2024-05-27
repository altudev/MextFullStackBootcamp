using MediatR;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersAuthController : ControllerBase
{
    private readonly ISender _mediatr;

    public UsersAuthController(ISender mediatr)
    {
        _mediatr = mediatr;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
}