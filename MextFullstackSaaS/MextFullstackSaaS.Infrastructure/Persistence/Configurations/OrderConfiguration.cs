using System.Text.Json;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullstackSaaS.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // IconDescription
            builder.Property(x => x.IconDescription)
                .HasMaxLength(200)
                .IsRequired();

            // ColourCode
            builder.Property(x => x.ColourCode)
                .HasMaxLength(15)
                .IsRequired();

            // Model
            builder.Property(x => x.Model)
                .HasConversion<int>()
                .IsRequired();

            // DesignType
            builder.Property(x => x.DesignType)
                .HasConversion<int>()
                .IsRequired();

            // IconSize
            builder.Property(x => x.Size)
                .HasConversion<int>()
                .IsRequired();

            // IconShape
            builder.Property(x => x.Shape)
                .HasConversion<int>()
                .IsRequired();

            // Quantity
            builder.Property(x => x.Quantity)
                .IsRequired();

            // Urls
            builder.Property(e => e.Urls)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));

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

            builder.ToTable("Orders");
        }
    }
}
