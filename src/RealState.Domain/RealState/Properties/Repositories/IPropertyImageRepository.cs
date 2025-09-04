using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Domain.RealState.Properties.Repositories;

/// <summary>
/// Contrato de persistencia para la entidad <see cref="PropertyImage"/>.
/// </summary>
public interface IPropertyImageRepository : IRepository<PropertyImage>
{
    /// <summary>
    /// Verifica si existe otra imagen con el mismo archivo asociada a una propiedad.
    /// </summary>
    Task<bool> ExistsSameFileAsync(Guid idProperty, string file, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene la cantidad de imágenes asociadas a una propiedad.
    /// </summary>
    Task<int> CountByPropertyAsync(Guid idProperty, CancellationToken cancellationToken = default);
}