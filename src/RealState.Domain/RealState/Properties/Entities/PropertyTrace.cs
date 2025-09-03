using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

public sealed class PropertyTrace : AuditEntity
{
    public Guid IdProperty { get; private set; }
    public DateTime DateSale { get; private set; }
    public string Name { get; private set; } = default!;
    public decimal Value { get; private set; }
    public decimal Tax { get; private set; }

    public PropertyTrace(Guid idProperty, DateTime dateSale, string name, decimal value, decimal tax)
    {
        IdProperty = idProperty;
        DateSale = dateSale;
        Name = name;
        Value = value;
        Tax = tax;
    }
}
