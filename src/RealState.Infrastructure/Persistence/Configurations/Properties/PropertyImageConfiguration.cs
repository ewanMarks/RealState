using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
{
    public void Configure(EntityTypeBuilder<PropertyImage> b)
    {
        b.ToTable("PropertyImage");
        b.HasKey(x => x.Id);
        b.Property(x => x.File).HasMaxLength(500).IsRequired();
        b.Property(x => x.Enabled).HasDefaultValue(true);

        b.HasOne(x => x.Property)
         .WithMany(p => p.Images)
         .HasForeignKey(x => x.IdProperty)
         .OnDelete(DeleteBehavior.Cascade);
    }
}