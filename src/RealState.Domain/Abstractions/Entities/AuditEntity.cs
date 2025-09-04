namespace RealState.Domain.Abstractions.Entities;

/// <summary>
/// Entidad base que agrega información de auditoría a todas las entidades del dominio.
/// </summary>
public abstract class AuditEntity : Entity
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
}
