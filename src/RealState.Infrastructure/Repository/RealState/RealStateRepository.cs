using RealState.Domain.Abstractions.Entities;
using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.Repository.Generics;

namespace RealState.Infrastructure.Repository.RealState;

/// <summary>
/// Implementación base del repositorio para el contexto <see cref="RealStateDbContext"/>.
/// </summary>
public class RealStateRepository<T>(RealStateDbContext context)
    : GenericRepository<T, RealStateDbContext>(context)
    where T : Entity
{
}
