using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Users.Entities;
using RealState.Domain.RealState.Users.Repositories;
using RealState.Infrastructure.Persistence.Context;

namespace RealState.Infrastructure.Repository.RealState.Users;

public class UserRepository(RealStateDbContext context)
    : RealStateRepository<User>(context), IUserRepository
{
    private readonly RealStateDbContext _context = context;

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default) =>
        _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}
