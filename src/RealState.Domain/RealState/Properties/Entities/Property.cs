using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

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

    public Property(string name, string address, decimal price, string codeInternal, int year, Guid idOwner)
    { 
        Name = name;
        Address = address;
        Price = price;
        CodeInternal = codeInternal;
        Year = year;
        IdOwner = idOwner; 
    }

    public void Update(string name, string address, string codeInternal, int year)
    {
        Name = name;
        Address = address;
        CodeInternal = codeInternal;
        Year = year;
    }

    public void SetOwner(Guid newOwnerId) => IdOwner = newOwnerId;

    public void SetPrice(decimal newPrice) => Price = newPrice;
}
