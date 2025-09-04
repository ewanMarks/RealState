using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Properties;

/// <summary>
/// Configuración de Entity Framework Core para la entidad <see cref="Property"/>.
/// </summary>
public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    /// <summary>
    /// Configura el mapeo de la entidad <see cref="Property"/> hacia la base de datos.
    /// </summary>
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        // Nombre de tabla y esquema
        builder.ToTable(nameof(Property), SchemaResources.Properties);

        // Clave primaria
        builder.HasKey(x => x.Id);

        // Relación obligatoria con Owner
        builder.Property(x => x.IdOwner)
            .IsRequired();

        // Propiedades básicas
        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)") // precisión monetaria
            .IsRequired();

        builder.Property(x => x.CodeInternal)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Year)
            .IsRequired();

        // Índices
        builder.HasIndex(x => x.CodeInternal).IsUnique(); // código interno único
        builder.HasIndex(x => x.IdOwner); // búsquedas rápidas por propietario

        // Relación con Owner (1 -> N)
        builder.HasOne<Owner>()
            .WithMany(o => o.Properties)
            .HasForeignKey(x => x.IdOwner)
            .OnDelete(DeleteBehavior.Restrict); // evita borrado en cascada
    }
}