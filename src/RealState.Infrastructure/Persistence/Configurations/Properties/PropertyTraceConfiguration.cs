using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
{
    public void Configure(EntityTypeBuilder<PropertyTrace> builder)
    {
        builder.ToTable(nameof(PropertyTrace), SchemaResources.Properties);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdPropertyTrace");

        builder.Property(x => x.IdProperty).IsRequired();

        builder.Property(x => x.DateSale)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Tax)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasIndex(x => x.IdProperty);
        builder.HasIndex(x => new { x.IdProperty, x.DateSale });

        builder.HasOne<Property>()
            .WithMany(p => p.Traces)
            .HasForeignKey(x => x.IdProperty)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.LastModifiedOn);
        builder.Property(x => x.LastModifiedBy);
    }
}
