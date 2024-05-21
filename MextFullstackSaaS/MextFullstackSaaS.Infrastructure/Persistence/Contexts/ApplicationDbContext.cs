using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
using MextFullstackSaaS.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MextFullstackSaaS.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<UserBalance> UserBalances { get; set; }
        public DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new OrderConfiguration());
            //builder.ApplyConfiguration(new UserBalanceConfiguration());
            //builder.ApplyConfiguration(new UserBalanceHistoryConfiguration());

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
