using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Emails;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler:IRequestHandler<UserAuthRegisterCommand,ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;

        public UserAuthRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterAsync(request, cancellationToken);
            
            var jwtDto = await _jwtService.GenerateTokenAsync(response.Id, response.Email,cancellationToken);

            // Send email verification
            
            await SendEmailVerificationAsync(response.Email, cancellationToken);
            
            return new ResponseDto<JwtDto>(jwtDto, "Welcome to our application!");
        }
        
        private async Task SendEmailVerificationAsync(string email, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendEmailVerificationDto();
        }
    }
}
