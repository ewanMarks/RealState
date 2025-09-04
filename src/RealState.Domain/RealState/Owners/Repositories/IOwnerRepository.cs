using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.ValueObjects;

namespace RealState.Domain.RealState.Owners.Repositories;

/// <summary>
/// Contrato de persistencia para la entidad <see cref="Owner"/>.
/// </summary>
public interface IOwnerRepository : IRepository<Owner>
{
    /// <summary>
    /// Verifica si un propietario tiene propiedades asociadas.
    /// </summary>
    /// <returns><c>true</c> si el propietario tiene propiedades vinculadas; de lo contrario, <c>false</c>.</returns>
    Task<bool> HasLinkedPropertiesAsync(Guid ownerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene una lista de propietarios aplicando filtros.
    /// </summary>
    /// <returns>Una colección de propietarios que cumplen con los filtros.</returns>
    Task<IReadOnlyList<Owner>> GetListAsync(OwnerFilters filters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cuenta el número de propietarios que cumplen con los filtros especificados.
    /// </summary>
    /// <returns>La cantidad de propietarios encontrados.</returns>
    Task<int> CountAsync(OwnerFilters filters, CancellationToken cancellationToken = default);
}
