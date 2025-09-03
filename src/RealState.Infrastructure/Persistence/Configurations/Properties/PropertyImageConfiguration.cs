using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
{
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        builder.ToTable(nameof(PropertyImage), SchemaResources.Properties);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdProperty).IsRequired();

        builder.Property(x => x.File)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Enabled)
            .IsRequired();

        builder.HasIndex(x => x.IdProperty);
        builder.HasIndex(x => new { x.IdProperty, x.File }).IsUnique();

        builder.HasOne<Property>()
            .WithMany(p => p.Images)
            .HasForeignKey(x => x.IdProperty)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.LastModifiedOn);
        builder.Property(x => x.LastModifiedBy);
    }
}