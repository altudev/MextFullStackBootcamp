using System.Text.RegularExpressions;
using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators;

public class UserAuthValidatorBase<T>:AbstractValidator<T> where T:class
{
    protected readonly IIdentityService _identityService;

    public UserAuthValidatorBase(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    // https://codeshare.io/vAP3oL

    protected bool IsEmail(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        
        return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
    }
}