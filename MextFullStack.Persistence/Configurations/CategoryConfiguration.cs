using MextFullStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullStack.Persistence.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Name
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Description
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            // IsActive
            builder
                .Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);


            // CreatedOn
            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId)
                .IsRequired()
                .HasMaxLength(100);

            // .HasDefaultValueSql("NOW()");

            // .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.ToTable("Categories");
        }
    }
}
