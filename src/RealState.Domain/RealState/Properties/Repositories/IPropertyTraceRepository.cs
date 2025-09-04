using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Domain.RealState.Properties.Repositories;

/// <summary>
/// Contrato de persistencia para la entidad <see cref="PropertyTrace"/>.
/// </summary>
public interface IPropertyTraceRepository : IRepository<PropertyTrace>
{
}