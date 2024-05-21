using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullstackSaaS.Infrastructure.Persistence.Configurations
{
    public class UserBalanceHistoryConfiguration: IEntityTypeConfiguration<UserBalanceHistory>
    {
        public void Configure(EntityTypeBuilder<UserBalanceHistory> builder)
        {
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // CurrentCredits
            builder.Property(x => x.CurrentCredits)
                .IsRequired();

            // PreviousCredits
            builder.Property(x => x.PreviousCredits)
                .IsRequired();

            // Amount
            builder.Property(x => x.Amount)
                .IsRequired();

            // Type
            builder.Property(x => x.Type)
                .HasConversion<int>()
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

            builder.ToTable("UserBalanceHistories");
        }
    }
}
