using MediatR;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;

public class UserAuthLoginCommand:IRequest<ResponseDto<JwtDto>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}