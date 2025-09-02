using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Owners;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> b)
    {
        b.ToTable("Owner");
        b.HasKey(x => x.Id);
        b.Property(x => x.Name).HasMaxLength(200).IsRequired();
        b.Property(x => x.Address).HasMaxLength(300);
        b.Property(x => x.Photo).HasMaxLength(500);
        b.Property(x => x.Birthday);
    }
}