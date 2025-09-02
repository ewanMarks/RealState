using RealState.Domain.Abstractions.Interfaces;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.UnitOfWorks;

public class UnitOfWork(RealStateDbContext db) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => db.SaveChangesAsync(cancellationToken);
}
