using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.SocialLogin;

public class UserAuthSocialLoginCommandHandler:IRequestHandler<UserAuthSocialLoginCommand, ResponseDto<JwtDto>>
{
    private readonly IIdentityService _identityService;

    public UserAuthSocialLoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<ResponseDto<JwtDto>> Handle(UserAuthSocialLoginCommand request, CancellationToken cancellationToken)
    {
        var jwtDto = await _identityService.SocialLoginAsync(request, cancellationToken);

        return new ResponseDto<JwtDto>(jwtDto, "Welcome back!");
    }
}