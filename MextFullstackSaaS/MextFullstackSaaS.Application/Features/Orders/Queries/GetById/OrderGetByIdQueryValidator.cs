using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQueryValidator:AbstractValidator<OrderGetByIdQuery>
    {
        private readonly IApplicationDbContext _dbContext;
        public OrderGetByIdQueryValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please select a valid order.");

            RuleFor(x => x.Id)
                .MustAsync(IsOrderExists)
                .WithMessage("The selected order does not exist in the database.");
        }

        public Task<bool> IsOrderExists(Guid id, CancellationToken cancellationToken)
        {
            // If the order exists we'll return true, otherwise we'll return false.
            // If we return true this will be a valid order.

            return _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
