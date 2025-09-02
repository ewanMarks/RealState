using RealState.Domain.Abstractions.Entities;
using RealState.Infrastructure.Persistence.Context;
using RealState.Infrastructure.Repository.Generics;

namespace RealState.Infrastructure.Repository.RealState;

public class RealStateRepository<T>(RealStateDbContext context)
    : GenericRepository<T, RealStateDbContext>(context)
    where T : Entity
{
}
