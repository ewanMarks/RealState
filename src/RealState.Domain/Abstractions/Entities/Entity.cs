namespace RealState.Domain.Abstractions.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    public void Active()
    {
        IsActive = true;
    }
    public void InActive()
    {
        IsActive = false;
    }
}
