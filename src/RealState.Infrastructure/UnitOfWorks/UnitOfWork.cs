using RealState.Domain.Abstractions.Interfaces;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.UnitOfWorks;

/// <summary>
/// Implementación del patrón Unit of Work para la base de datos RealState.
/// </summary>
public class UnitOfWork(RealStateDbContext db) : IUnitOfWork
{
    /// <summary>
    /// Persiste los cambios pendientes en el contexto de base de datos.
    /// </summary>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => db.SaveChangesAsync(cancellationToken);
}
