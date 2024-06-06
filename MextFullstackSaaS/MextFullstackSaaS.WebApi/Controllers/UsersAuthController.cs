using MediatR;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersAuthController(ISender mediatr) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
    { 
        return Ok(await mediatr.Send(command, cancellationToken));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult>LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
    { 
        return Ok(await mediatr.Send(command, cancellationToken));
    }
    
    [HttpGet("verify-email")]
    public async Task<IActionResult>VerifyEmailAsync([FromQuery] UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
    { 
        return Ok(await mediatr.Send(command, cancellationToken));
    }
}