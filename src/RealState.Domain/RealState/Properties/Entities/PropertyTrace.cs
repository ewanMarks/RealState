using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

/// <summary>
/// Entidad de dominio que representa un registro histórico asociado a una propiedad inmobiliaria.
/// </summary>
public sealed class PropertyTrace : AuditEntity
{
    public Guid IdProperty { get; private set; }
    public DateTime DateSale { get; private set; }
    public string Name { get; private set; } = default!;
    public decimal Value { get; private set; }
    public decimal Tax { get; private set; }

    /// <summary>
    /// Constructor de la entidad <see cref="PropertyTrace"/>.
    /// </summary>
    /// <param name="idProperty">Identificador de la propiedad asociada.</param>
    /// <param name="dateSale">Fecha de la venta o evento.</param>
    /// <param name="name">Nombre de la persona o entidad involucrada.</param>
    /// <param name="value">Valor monetario de la operación.</param>
    /// <param name="tax">Impuesto aplicado en la operación.</param>
    public PropertyTrace(Guid idProperty, DateTime dateSale, string name, decimal value, decimal tax)
    {
        IdProperty = idProperty;
        DateSale = dateSale;
        Name = name;
        Value = value;
        Tax = tax;
    }
}
