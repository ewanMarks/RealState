using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable(nameof(Property), SchemaResources.Properties);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdOwner).IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.CodeInternal)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Year)
            .IsRequired();

        builder.HasIndex(x => x.CodeInternal).IsUnique();
        builder.HasIndex(x => x.IdOwner);

        builder.HasOne<Owner>()
            .WithMany(o => o.Properties)
            .HasForeignKey(x => x.IdOwner)
            .OnDelete(DeleteBehavior.Restrict);
    }
}