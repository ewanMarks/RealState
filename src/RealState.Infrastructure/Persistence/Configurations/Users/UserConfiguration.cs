using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Users.Entities;

namespace RealState.Infrastructure.Persistence.Configurations.Users;

/// <summary>
/// Configuración de Entity Framework Core para la entidad <see cref="User"/>.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Configura el mapeo de la entidad <see cref="User"/> hacia la base de datos.
    /// </summary>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Nombre de tabla y esquema
        builder.ToTable(nameof(User), SchemaResources.Adm);

        // Clave primaria
        builder.HasKey(x => x.Id);

        // Propiedades básicas
        builder.Property(x => x.Email)
            .HasMaxLength(256)
            .IsRequired();

        // Índice único para garantizar que no haya correos duplicados
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(512)
            .IsRequired();

        builder.Property(x => x.PasswordSalt)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Role)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        // Propiedades de auditoría
        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.LastModifiedOn);
        builder.Property(x => x.LastModifiedBy);
    }
}