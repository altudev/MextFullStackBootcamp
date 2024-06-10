using MextFullstackSaaS.Application.Common.Models.Emails;

namespace MextFullstackSaaS.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto,CancellationToken cancellationToken);
    Task SendForgotPasswordAsync(EmailSendEmailVerificationDto emailDto,CancellationToken cancellationToken);
}