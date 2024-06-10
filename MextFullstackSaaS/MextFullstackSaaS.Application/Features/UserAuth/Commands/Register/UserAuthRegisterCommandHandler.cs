using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Emails;
using MextFullstackSaaS.Application.Common.Translations;
using Microsoft.Extensions.Localization;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler:IRequestHandler<UserAuthRegisterCommand,ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IStringLocalizer<CommonTranslations> _localizer;

        public UserAuthRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService, IEmailService emailService, IStringLocalizer<CommonTranslations> localizer)
        {
            _identityService = identityService;
            _jwtService = jwtService;
            _emailService = emailService;
            _localizer = localizer;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterAsync(request, cancellationToken);
            
            var jwtDtoTask = _jwtService.GenerateTokenAsync(response.Id, response.Email,cancellationToken);
            
            var sendEmailTask = SendEmailVerificationAsync(response.Email,response.FirstName, response.EmailToken, cancellationToken);
            
            await Task.WhenAll(jwtDtoTask, sendEmailTask);
            
            return new ResponseDto<JwtDto>(await jwtDtoTask, _localizer[CommonTranslationKeys.UserAuthRegisterSucceededMessage]);
        }
        
        private Task SendEmailVerificationAsync(string email,string firstName, string emailToken, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendEmailVerificationDto(email,firstName,emailToken);
            
            return _emailService.SendEmailVerificationAsync(emailDto, cancellationToken);
        }
    }
}
