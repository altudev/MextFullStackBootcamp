using System.Text.Json;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullstackSaaS.Infrastructure.Persistence.Configurations
{
    public class UserPaymentConfiguration:IEntityTypeConfiguration<UserPayment>
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        public void Configure(EntityTypeBuilder<UserPayment> builder)
        {
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // ConversationId
            builder.Property(x => x.ConversationId)
                .HasMaxLength(100)
                .IsRequired();

            // BasketId
            builder.Property(x => x.BasketId)
                .HasMaxLength(100)
                .IsRequired();

            // Token
            builder.Property(x => x.Token)
                .HasMaxLength(300)
                .IsRequired();

            // Price
            builder.Property(x => x.Price)
                .IsRequired();

            // PaidPrice
            builder.Property(x => x.PaidPrice)
                .IsRequired();

            // CurrencyCode
            builder.Property(x => x.CurrencyCode)
                .HasConversion<int>()
                .IsRequired();

            // Note
            builder.Property(x => x.Note)
                .HasMaxLength(1000)
                .IsRequired(false);

            // RefundedAmount
            builder.Property(x => x.RefundedAmount)
                .IsRequired(false);

            // Status
            builder.Property(x => x.Status)
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


            builder.Property(e => e.UserPaymentDetail)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, _options),
                    v => JsonSerializer.Deserialize<UserPaymentDetail>(v, _options),
                    new ValueComparer<UserPaymentDetail>(
                        (c1, c2) => JsonSerializer.Serialize(c1, _options) == JsonSerializer.Serialize(c2, _options),
                        c => c == null ? 0 : JsonSerializer.Serialize(c, _options).GetHashCode(),
                        c => c == null ? null : JsonSerializer.Deserialize<UserPaymentDetail>(JsonSerializer.Serialize(c, _options), _options)))
                .HasColumnType("jsonb");

            // Relationships

            builder.HasMany<UserPaymentHistory>(x => x.Histories)
                .WithOne(h => h.UserPayment)
                .HasForeignKey(h => h.UserPaymentId);

            builder.ToTable("UserPayments");
        }
    }
}
