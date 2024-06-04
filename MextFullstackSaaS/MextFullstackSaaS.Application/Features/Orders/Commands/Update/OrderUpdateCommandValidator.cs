using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Update;

public class OrderUpdateCommandValidator:AbstractValidator<OrderUpdateCommand>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ICurrentUserService _currentUserService;
    public OrderUpdateCommandValidator(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
    {
        _dbContext = dbContext;
        _currentUserService = currentUserService;
        
        RuleFor(x=>x.IconDescription)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("The icon description must be less than 200 characters.");

        RuleFor(x => x.ColourCode)
            .NotEmpty()
            .MaximumLength(15)
            .WithMessage("The colour code must be less than 15 characters.");

        RuleFor(x => x.Model)
            .IsInEnum()
            .WithMessage("Please select a valid model.");

        RuleFor(x => x.DesignType)
            .IsInEnum()
            .WithMessage("Please select a valid design type.");

        RuleFor(x => x.Size)
            .IsInEnum()
            .WithMessage("Please select a valid size.");

        RuleFor(x => x.Shape)
            .IsInEnum()
            .WithMessage("Please select a valid shape.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .LessThanOrEqualTo(6)
            .WithMessage("Please select a valid quantity.");

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Please select a valid order.");
        
        RuleFor(x => x.Id)
            .MustAsync(IsOrderExistsAsync)
            .WithMessage("The selected order does not exist in the database.");

        RuleFor(x => x.Id)
            .MustAsync(IsTheSameUserAsync)
            .WithMessage("You are not authorized to delete this order.");   
    }
    
    private Task<bool> IsOrderExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);
    }
        
    private Task<bool> IsTheSameUserAsync(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext
            .Orders
            .Where(x=>x.UserId == _currentUserService.UserId)
            .AnyAsync(x => x.Id == id, cancellationToken);
    }
}