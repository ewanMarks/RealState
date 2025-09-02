using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
{
    public void Configure(EntityTypeBuilder<PropertyTrace> b)
    {
        b.ToTable("PropertyTrace");
        b.HasKey(x => x.Id);
        b.Property(x => x.DateSale).IsRequired();
        b.Property(x => x.Name).HasMaxLength(200);
        b.Property(x => x.Value).HasPrecision(18, 2).IsRequired();
        b.Property(x => x.Tax).HasPrecision(18, 2).IsRequired();

        b.HasOne(x => x.Property)
         .WithMany(p => p.Traces)
         .HasForeignKey(x => x.IdProperty)
         .OnDelete(DeleteBehavior.Cascade);
    }
}
