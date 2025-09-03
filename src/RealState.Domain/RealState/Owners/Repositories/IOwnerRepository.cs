using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.ValueObjects;

namespace RealState.Domain.RealState.Owners.Repositories;

public interface IOwnerRepository : IRepository<Owner>
{
    Task<bool> HasLinkedPropertiesAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Owner>> GetListAsync(OwnerFilters filters, CancellationToken cancellationToken = default);
    Task<int> CountAsync(OwnerFilters filters, CancellationToken cancellationToken = default);
}
