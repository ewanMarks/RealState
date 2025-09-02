using RealState.Domain.Abstractions.Entities;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

public sealed class Property : AuditEntity
{
    public string Name { get; private set; } = default!;
    public string? Address { get; private set; }
    public decimal Price { get; private set; }
    public string CodeInternal { get; private set; } = default!;
    public int Year { get; private set; }
    public Guid IdOwner { get; private set; }
    public Owner Owner { get; private set; } = default!;
    private readonly List<PropertyImage> _images = new();
    private readonly List<PropertyTrace> _traces = new();
    public IReadOnlyCollection<PropertyImage> Images => _images;
    public IReadOnlyCollection<PropertyTrace> Traces => _traces;

    public Property(string name, string? address, decimal price, string codeInternal, int year, Guid idOwner)
    { Name = name; Address = address; Price = price; CodeInternal = codeInternal; Year = year; IdOwner = idOwner; }

    public void ChangePrice(decimal newPrice) => Price = newPrice;
}
