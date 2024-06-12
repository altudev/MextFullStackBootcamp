using System.Web;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.Emails;
using MextFullstackSaaS.Application.Common.Translations;
using Microsoft.Extensions.Localization;
using Resend;

namespace MextFullstackSaaS.Infrastructure.Services;

public class ResendEmailManager:IEmailService
{
    private readonly IResend _resend;
    private readonly IRootPathService _rootPathService;
    private readonly IStringLocalizer<CommonTranslations> _localizer;

    public ResendEmailManager(IResend resend, IRootPathService rootPathService, IStringLocalizer<CommonTranslations> localizer)
    {
        _resend = resend;
        _rootPathService = rootPathService;
        _localizer = localizer;
    }

    private const string WebAppBaseUrl = "http://localhost:5262/";
    public async Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
    {
        var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
        
        var encodedToken = HttpUtility.UrlEncode(emailDto.Token);
        
        var link = $"{WebAppBaseUrl}verify-email?email={encodedEmail}&token={encodedToken}";

        var htmlContent =
            await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html",cancellationToken);

        htmlContent = htmlContent.Replace("{{{link}}}", link);

        htmlContent = htmlContent.Replace("{{{subject}}}", _localizer[CommonTranslationKeys.EmailVerificationSubject]);

        htmlContent = htmlContent.Replace("{{{content}}}", _localizer[CommonTranslationKeys.EmailVerificationContent]);

        htmlContent = htmlContent.Replace("{{{buttonText}}}", _localizer[CommonTranslationKeys.EmailVerificationButtonText]);

        await SendEmailAsync(new EmailSendDto(emailDto.Email, _localizer[CommonTranslationKeys.EmailVerificationSubject], htmlContent), cancellationToken);
    }

    public async Task SendForgotPasswordAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
    {
        var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);

        var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

        var link = $"{WebAppBaseUrl}UsersAuth/verify-email?email={encodedEmail}&token={encodedToken}";

        var htmlContent =
            await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html", cancellationToken);

        htmlContent = htmlContent.Replace("{{{link}}}", link);

        htmlContent = htmlContent.Replace("{{{subject}}}", "Email Verification");

        htmlContent = htmlContent.Replace("{{{content}}}", "Kindly click the button below to confirm your email address.");

        htmlContent = htmlContent.Replace("{{{buttonText}}}", "Verify Email");

        await SendEmailAsync(new EmailSendDto(emailDto.Email, "Forgot Password", htmlContent), cancellationToken);
    }

    private Task SendEmailAsync(EmailSendDto emailSendDto, CancellationToken cancellationToken)
    {
        var message = new EmailMessage();

        message.From = "noreply@yazilim.academy";

        foreach (var emailAddress in emailSendDto.Addresses)
            message.To.Add(emailAddress);
        
        message.Subject = emailSendDto.Subject;
        message.HtmlBody = emailSendDto.HtmlContent;

        return _resend.EmailSendAsync(message, cancellationToken);
    }
}