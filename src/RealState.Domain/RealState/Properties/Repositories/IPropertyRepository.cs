using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.ValueObjects;

namespace RealState.Domain.RealState.Properties.Repositories;

/// <summary>
/// Contrato de persistencia para la entidad <see cref="Property"/>.
/// </summary>
public interface IPropertyRepository : IRepository<Property>
{
    /// <summary>
    /// Verifica si ya existe una propiedad con el mismo código interno.
    /// </summary>
    Task<bool> CodeInternalExistsAsync(string codeInternal, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifica si ya existe una propiedad con el mismo código interno,
    /// excluyendo una propiedad específica.
    /// </summary>
    Task<bool> CodeInternalExistsForOtherAsync(Guid idProperty, string codeInternal, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene una lista de propiedades aplicando filtros de búsqueda.
    /// </summary>
    Task<IReadOnlyList<Property>> GetListAsync(PropertyFilters filters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cuenta el número de propiedades que cumplen con los filtros especificados.
    /// </summary>
    Task<int> CountAsync(PropertyFilters filters, CancellationToken cancellationToken = default);
}