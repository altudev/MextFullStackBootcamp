using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;
using MextFullstackSaaS.Domain.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MextFullstackSaaS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersAuthController : ControllerBase
{
    private readonly ISender _mediatr;
    private readonly GoogleSettings _googleSettings;
    private const string RedirectUri = "https://localhost:7281/api/UsersAuth/signin-google";
    private readonly string _googleAuthorizationUrl;
    public UsersAuthController(ISender mediatr, IOptions<GoogleSettings> googleSettings)
    {
        _mediatr = mediatr;
        
        _googleSettings = googleSettings.Value;
        
        _googleAuthorizationUrl = $"https://accounts.google.com/o/oauth2/v2/auth?" +
            $"client_id={_googleSettings.ClientId}&" +
            $"response_type=code&" +
            $"scope=openid%20email%20profile&" +
            $"access_type=offline&" +
            $"redirect_uri={RedirectUri}";
    }

    [HttpGet("signin-google-start")]
    public IActionResult SignInGoogleStart()
        =>  Redirect(_googleAuthorizationUrl);
    
    [HttpGet("signin-google")]
    public async Task<IActionResult> SignInGoogleAsync(string code, CancellationToken cancellationToken)
    {
        var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
        {
            ClientSecrets = new ClientSecrets()
            {
                ClientId = _googleSettings.ClientId,
                ClientSecret = _googleSettings.ClientSecret,
            }
        });

        var tokenResponse = await flow.ExchangeCodeForTokenAsync(
            userId: "user",
            code: code,
            redirectUri: RedirectUri,
            cancellationToken
        );

        var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);

        var email = payload.Email;
        var firstName = payload.GivenName;
        var lastName = payload.FamilyName;

        // var jwtDto =
        //     await _authenticationService.SocialLoginAsync(userEmail, firstName, lastName, cancellationToken);
        //
        // var queryParams = new Dictionary<string, string>()
        // {
        //     {"access_token",jwtDto.AccessToken },
        //     {"expiry_date",jwtDto.ExpiryDate.ToBinary().ToString() },
        // };

        // var formContent = new FormUrlEncodedContent(queryParams);
        //
        // var query = await formContent.ReadAsStringAsync(cancellationToken);
        //
        // var redirectUrl = $"http://127.0.0.1:5173/social-login?{query}";

        return Redirect($"http://localhost:5262/social-login?email={email}&firstName={firstName}&lastName={lastName}");
    }

    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
    { 
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult>LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
    { 
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
    
    [HttpGet("verify-email")]
    public async Task<IActionResult>VerifyEmailAsync([FromQuery] UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
}