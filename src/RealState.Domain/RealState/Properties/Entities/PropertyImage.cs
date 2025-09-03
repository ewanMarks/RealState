using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

public sealed class PropertyImage : AuditEntity
{
    public Guid IdProperty { get; private set; }
    public string File { get; private set; } = default!;
    public bool Enabled { get; private set; }

    public PropertyImage(Guid idProperty, string file, bool enabled)
    {
        IdProperty = idProperty;
        File = file;
        Enabled = enabled;
    }

    public void Enable() => Enabled = true;
    public void Disable() => Enabled = false;

    public void UpdateFile(string newFile) => File = newFile;
}