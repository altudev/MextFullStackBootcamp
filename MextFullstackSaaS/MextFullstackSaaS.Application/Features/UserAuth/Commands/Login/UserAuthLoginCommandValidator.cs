using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;

public class UserAuthLoginCommandValidator:AbstractValidator<UserAuthLoginCommand>
{
    private readonly IIdentityService _identityService;
    
    public UserAuthLoginCommandValidator(IIdentityService identityService)
    {
        _identityService = identityService;
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        
        RuleFor(x=>x.Email)
            .MustAsync((x,y,cancellationToken) => CheckPasswordSignInAsync(x.Email, x.Password, cancellationToken))
            .WithMessage("Your email or password is incorrect. Please try again.");
    }
    
    private Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
    {
        return _identityService.CheckPasswordSignInAsync(email, password, cancellationToken);
    }
}