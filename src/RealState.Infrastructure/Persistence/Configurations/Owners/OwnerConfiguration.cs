using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Owners;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable(nameof(Owner), SchemaResources.Owners);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(300);

        builder.Property(x => x.Photo)
            .HasMaxLength(500);

        builder.Property(x => x.Birthday);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasIndex(x => x.IsActive);

        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.Property(x => x.LastModifiedOn);

        builder.Property(x => x.LastModifiedBy);
    }
}