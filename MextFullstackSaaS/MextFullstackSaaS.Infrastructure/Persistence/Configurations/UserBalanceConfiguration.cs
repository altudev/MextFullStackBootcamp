using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullstackSaaS.Infrastructure.Persistence.Configurations
{
    public class UserBalanceConfiguration:IEntityTypeConfiguration<UserBalance>
    {
        public void Configure(EntityTypeBuilder<UserBalance> builder)
        {
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Credits
            builder.Property(x => x.Credits)
                .IsRequired();

            // Common Properties

            // CreatedDate
            builder.Property(x => x.CreatedOn).IsRequired();

            // CreatedByUserId
            builder.Property(user => user.CreatedByUserId)
                .HasMaxLength(100)
                .IsRequired();

            // ModifiedDate
            builder.Property(user => user.ModifiedOn)
                .IsRequired(false);

            // ModifiedByUserId
            builder.Property(user => user.ModifiedByUserId)
                .HasMaxLength(100)
                .IsRequired(false);

            // Relationships
            //builder.HasOne<User>(x => x.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(x => x.UserId);

            builder.HasMany<UserBalanceHistory>(x=>x.Histories)
                .WithOne(h => h.UserBalance)
                .HasForeignKey(h => h.UserBalanceId);

            builder.ToTable("UserBalances");
        }
    }
}
