using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Owners.Entities;

namespace RealState.Domain.RealState.Owners.Repositories;

public interface IOwnerRepository : IRepository<Owner>
{
    Task<bool> HasLinkedPropertiesAsync(Guid ownerId, CancellationToken cancellationToken = default);
}
