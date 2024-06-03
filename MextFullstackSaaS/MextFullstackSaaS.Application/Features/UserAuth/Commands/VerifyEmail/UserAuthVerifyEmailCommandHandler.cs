using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;

public class UserAuthVerifyEmailCommandHandler:IRequestHandler<UserAuthVerifyEmailCommand,ResponseDto<string>>
{
    private readonly IIdentityService _identityService;

    public UserAuthVerifyEmailCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<ResponseDto<string>> Handle(UserAuthVerifyEmailCommand request, CancellationToken cancellationToken)
    {
        await _identityService.VerifyEmailAsync(request, cancellationToken);
        
        return new ResponseDto<string>(request.Email,"Email verified successfully.");
    }
}