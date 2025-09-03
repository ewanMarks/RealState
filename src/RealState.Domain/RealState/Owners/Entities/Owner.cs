using RealState.Domain.Abstractions.Entities;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Domain.RealState.Owners.Entities;

public sealed class Owner : AuditEntity
{
    public string Name { get; private set; } = default!;
    public string? Address { get; private set; }
    public string? Photo { get; private set; }
    public DateOnly? Birthday { get; private set; }

    private readonly List<Property> _properties = new();
    public IReadOnlyCollection<Property> Properties => _properties;

    public Owner(string name, string? address, string? photo, DateOnly? birthday)
    {
        Name = name;
        Address = address;
        Photo = photo;
        Birthday = birthday;
    }

    public void Deactivate() => InActive();
    public void Activate() => Active();

}
