using MextFullstackSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullstackSaaS.Infrastructure.Persistence.Configurations
{
    public class UserPaymentHistoryConfiguration:IEntityTypeConfiguration<UserPaymentHistory>
    {
        public void Configure(EntityTypeBuilder<UserPaymentHistory> builder)
        {
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // ConversationId
            builder.Property(x => x.ConversationId)
                .HasMaxLength(100)
                .IsRequired(false);

            // Status
            builder.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();

            // Note
            builder.Property(x => x.Note)
                .IsRequired(false)
                .HasMaxLength(1000);

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

            builder.ToTable("UserPaymentHistories");
        }
    }
}
