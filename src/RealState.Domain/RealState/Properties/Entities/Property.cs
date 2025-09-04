using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

/// <summary>
/// Entidad de dominio que representa una propiedad inmobiliaria.
/// </summary>
public sealed class Property : AuditEntity
{
    public string Name { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public decimal Price { get; private set; }
    public string CodeInternal { get; private set; } = default!;
    public int Year { get; private set; }
    public Guid IdOwner { get; private set; }

    private readonly List<PropertyImage> _images = new();
    private readonly List<PropertyTrace> _traces = new();

    public IReadOnlyCollection<PropertyImage> Images => _images;
    public IReadOnlyCollection<PropertyTrace> Traces => _traces;

    /// <summary>
    /// Constructor de la entidad <see cref="Property"/>.
    /// </summary>
    /// <param name="name">Nombre de la propiedad.</param>
    /// <param name="address">Dirección física.</param>
    /// <param name="price">Precio inicial de la propiedad.</param>
    /// <param name="codeInternal">Código interno de referencia.</param>
    /// <param name="year">Año de construcción.</param>
    /// <param name="idOwner">Identificador del propietario asociado.</param>
    public Property(string name, string address, decimal price, string codeInternal, int year, Guid idOwner)
    { 
        Name = name;
        Address = address;
        Price = price;
        CodeInternal = codeInternal;
        Year = year;
        IdOwner = idOwner; 
    }

    /// <summary>
    /// Actualiza los datos básicos de la propiedad (excepto el precio y el propietario).
    /// </summary>
    public void Update(string name, string address, string codeInternal, int year)
    {
        Name = name;
        Address = address;
        CodeInternal = codeInternal;
        Year = year;
    }

    /// <summary>
    /// Cambia el propietario asociado a la propiedad.
    /// </summary>
    public void SetOwner(Guid newOwnerId) => IdOwner = newOwnerId;

    /// <summary>
    /// Actualiza el precio de la propiedad.
    /// </summary>
    public void SetPrice(decimal newPrice) => Price = newPrice;
}
