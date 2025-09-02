using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Owners;

public class OwnerRepository(RealStateDbContext context)
    : RealStateRepository<Owner>(context), IOwnerRepository
{
    private readonly RealStateDbContext _context = context;

    public Task<bool> HasLinkedPropertiesAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        _context.Properties.AsNoTracking()
            .AnyAsync(p => p.IdOwner == ownerId, cancellationToken);
}
