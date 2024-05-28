namespace MextFullstackSaaS.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendEmailVerificationAsync(string email, string subject, string message);
}