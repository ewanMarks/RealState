using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Properties.Entities;

public sealed class PropertyImage : AuditEntity
{
    public Guid IdProperty { get; private set; }
    public Property Property { get; private set; } = default!;
    public string File { get; private set; } = default!;
    public bool Enabled { get; private set; }

    public PropertyImage(Guid idProperty, string file, bool enabled = true)
    { IdProperty = idProperty; File = file; Enabled = enabled; }
}
