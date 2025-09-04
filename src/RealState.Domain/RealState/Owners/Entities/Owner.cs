using RealState.Domain.Abstractions.Entities;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Domain.RealState.Owners.Entities;

/// <summary>
/// Entidad de dominio que representa a un propietario de bienes inmuebles.
/// </summary>
public sealed class Owner : AuditEntity
{
    public string Name { get; private set; } = default!;
    public string? Address { get; private set; }
    public string? Photo { get; private set; }
    public DateOnly? Birthday { get; private set; }

    private readonly List<Property> _properties = new();
    public IReadOnlyCollection<Property> Properties => _properties;


    /// <summary>
    /// Constructor de la entidad <see cref="Owner"/>.
    /// </summary>
    /// <param name="name">Nombre completo del propietario.</param>
    /// <param name="address">Dirección física (opcional).</param>
    /// <param name="photo">Fotografía o URL/base64 (opcional).</param>
    /// <param name="birthday">Fecha de nacimiento (opcional).</param>
    public Owner(string name, string? address, string? photo, DateOnly? birthday)
    {
        Name = name;
        Address = address;
        Photo = photo;
        Birthday = birthday;
    }

    /// <summary>
    /// Marca al propietario como inactivo (soft delete).
    /// </summary>
    public void Deactivate() => InActive();

    /// <summary>
    /// Marca al propietario como activo.
    /// </summary>
    public void Activate() => Active();

}
