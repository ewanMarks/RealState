using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

/// <summary>
/// Configuración de Entity Framework Core para la entidad <see cref="PropertyImage"/>.
/// </summary>
public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
{
    /// <summary>
    /// Configura el mapeo de la entidad <see cref="PropertyImage"/> hacia la base de datos.
    /// </summary>
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        // Nombre de tabla y esquema
        builder.ToTable(nameof(PropertyImage), SchemaResources.Properties);

        // Clave primaria
        builder.HasKey(x => x.Id);

        // Relación obligatoria con Property
        builder.Property(x => x.IdProperty)
            .IsRequired();

        // Propiedades básicas
        builder.Property(x => x.File)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Enabled)
            .IsRequired();

        // Índices
        builder.HasIndex(x => x.IdProperty);
        builder.HasIndex(x => new { x.IdProperty, x.File }).IsUnique();

        // Relación con Property (1 -> N)
        builder.HasOne<Property>()
            .WithMany(p => p.Images)
            .HasForeignKey(x => x.IdProperty)
            .OnDelete(DeleteBehavior.Cascade); // si se elimina una propiedad, también sus imágenes

        // Propiedades de auditoría
        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.LastModifiedOn);
        builder.Property(x => x.LastModifiedBy);
    }
}