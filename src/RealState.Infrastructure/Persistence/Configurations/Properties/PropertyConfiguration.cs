using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> b)
    {
        b.ToTable("Property");
        b.HasKey(x => x.Id);
        b.Property(x => x.Name).HasMaxLength(200).IsRequired();
        b.Property(x => x.Address).HasMaxLength(300);
        b.Property(x => x.Price).HasPrecision(18, 2).IsRequired();
        b.Property(x => x.CodeInternal).HasMaxLength(50).IsRequired();
        b.HasIndex(x => x.CodeInternal).IsUnique();
        b.Property(x => x.Year).IsRequired();

        b.HasOne(x => x.Owner)
         .WithMany(o => o.Properties)
         .HasForeignKey(x => x.IdOwner)
         .OnDelete(DeleteBehavior.Restrict);
    }
}