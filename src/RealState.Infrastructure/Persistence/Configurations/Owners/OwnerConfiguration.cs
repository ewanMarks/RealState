using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Owners;

/// <summary>
/// Configuración de Entity Framework Core para la entidad <see cref="Owner"/>.
/// </summary>
public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    /// <summary>
    /// Configura el mapeo de la entidad <see cref="Owner"/> hacia la base de datos.
    /// </summary>
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        // Nombre de tabla y esquema
        builder.ToTable(nameof(Owner), SchemaResources.Owners);

        // Clave primaria
        builder.HasKey(x => x.Id);

        // Propiedades básicas
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

        // Índices
        builder.HasIndex(x => x.IsActive);

        // Propiedades de auditoría
        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.Property(x => x.LastModifiedOn);

        builder.Property(x => x.LastModifiedBy);
    }
}