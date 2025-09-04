using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Users.Entities;

namespace RealState.Domain.RealState.Users.Repositories;

/// <summary>
/// Contrato de persistencia para la entidad <see cref="User"/>.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Obtiene un usuario a partir de su dirección de correo electrónico.
    /// </summary>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}