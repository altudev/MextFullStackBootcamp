using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandValidator: AbstractValidator<OrderDeleteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public OrderDeleteCommandValidator(IApplicationDbContext dbContext)
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
