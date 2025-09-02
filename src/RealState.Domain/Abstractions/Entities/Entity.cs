namespace RealState.Domain.Abstractions.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}
