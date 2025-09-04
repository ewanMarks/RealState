using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Repositories;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Properties;

/// <summary>
/// Implementación del repositorio <see cref="IPropertyTraceRepository"/> 
/// para la entidad <see cref="PropertyTrace"/>.
/// </summary>
public class PropertyTraceRepository(RealStateDbContext context)
    : RealStateRepository<PropertyTrace>(context), IPropertyTraceRepository
{
}