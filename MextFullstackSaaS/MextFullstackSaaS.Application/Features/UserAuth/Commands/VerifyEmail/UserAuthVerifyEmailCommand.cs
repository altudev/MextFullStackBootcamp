using MediatR;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;

public class UserAuthVerifyEmailCommand:IRequest<ResponseDto<string>>
{
    public string Email { get; set; }
    public string Token { get; set; }

    public UserAuthVerifyEmailCommand(string email, string token)
    {
        Email = email;

        Token = token;
    }

    public UserAuthVerifyEmailCommand()
    {
        
    }
}