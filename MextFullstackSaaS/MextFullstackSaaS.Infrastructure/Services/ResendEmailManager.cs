using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.Emails;
using Resend;

namespace MextFullstackSaaS.Infrastructure.Services;

public class ResendEmailManager:IEmailService
{
    private readonly IResend _resend;

    public ResendEmailManager(IResend resend)
    {
        _resend = resend;
    }

    private const string ApiBaseUrl = "https://localhost:7281/api/";
    public Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
    {
        // https://codeshare.io/64xePY
        
        var link = $"{ApiBaseUrl}UsersAuth/VerifyEmail?email={emailDto.Email}&token={emailDto.Token}";
        
        var message = new EmailMessage();
        message.From = "alper.tunga@yazilim.academy";
        message.To.Add( emailDto.Email);
        message.Subject = "Email Verification | IconBuilderAI";
        message.HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>";

        return _resend.EmailSendAsync( message,cancellationToken);
    }
}