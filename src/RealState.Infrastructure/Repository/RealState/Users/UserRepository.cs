using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Users.Entities;
using RealState.Domain.RealState.Users.Repositories;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Users;

/// <summary>
/// Implementación del repositorio <see cref="IUserRepository"/> 
/// para la entidad <see cref="User"/>.
/// </summary>
public class UserRepository(RealStateDbContext context)
    : RealStateRepository<User>(context), IUserRepository
{
    private readonly RealStateDbContext _context = context;

    /// <summary>
    /// Obtiene un usuario a partir de su dirección de correo electrónico.
    /// </summary>
    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default) =>
        _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}
