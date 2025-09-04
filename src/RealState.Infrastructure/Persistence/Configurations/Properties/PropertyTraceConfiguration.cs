using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

/// <summary>
/// Configuración de Entity Framework Core para la entidad <see cref="PropertyTrace"/>.
/// </summary>
public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
{
    /// <summary>
    /// Configura el mapeo de la entidad <see cref="PropertyTrace"/> hacia la base de datos.
    /// </summary>
    public void Configure(EntityTypeBuilder<PropertyTrace> builder)
    {
        // Nombre de tabla y esquema
        builder.ToTable(nameof(PropertyTrace), SchemaResources.Properties);

        // Clave primaria
        builder.HasKey(x => x.Id);

        // Mapeo de columna personalizada
        builder.Property(x => x.Id)
            .HasColumnName("IdPropertyTrace");

        // Relación obligatoria con Property
        builder.Property(x => x.IdProperty)
            .IsRequired();

        // Propiedades básicas
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

        // Índices
        builder.HasIndex(x => x.IdProperty);
        builder.HasIndex(x => new { x.IdProperty, x.DateSale });

        // Relación con Property (1 -> N)
        builder.HasOne<Property>()
            .WithMany(p => p.Traces)
            .HasForeignKey(x => x.IdProperty)
            .OnDelete(DeleteBehavior.Cascade); // si se elimina una propiedad, también sus trazas

        // Propiedades de auditoría
        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.LastModifiedOn);
        builder.Property(x => x.LastModifiedBy);
    }
}
