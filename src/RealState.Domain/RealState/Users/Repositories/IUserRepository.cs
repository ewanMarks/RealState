using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Users.Entities;

namespace RealState.Domain.RealState.Users.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}