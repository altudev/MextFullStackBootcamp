using FluentValidation;
using MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;

public class UserAuthRegisterCommandValidator:UserAuthValidatorBase<UserAuthRegisterCommand>
{
    public UserAuthRegisterCommandValidator(IIdentityService identityService):base(identityService)
    {
        
        https://codeshare.io/zlPJyO
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .Must(IsEmail).WithMessage("Email is not valid");
            // .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required");
        
        RuleFor(x=>x.Email)
            .MustAsync(CheckIfUserExists)
            .WithMessage("User with this email already exists");
    }
    
    private async Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
    {
        return !await _identityService.IsEmailExistsAsync(email, cancellationToken);
    }
}