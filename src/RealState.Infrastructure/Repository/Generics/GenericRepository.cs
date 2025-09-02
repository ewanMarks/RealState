using Microsoft.EntityFrameworkCore;
using RealState.Domain.Abstractions.Entities;
using RealState.Domain.Abstractions.Interfaces;
using System.Linq.Expressions;

namespace RealState.Infrastructure.Repository.Generics;

public class GenericRepository<T, TC>(DbContext context) : IRepository<T>
    where T : Entity
    where TC : DbContext
{
    protected readonly DbContext _context = context;

    #region Métodos Genericos
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _context.Set<T>().FindAsync([id], cancellationToken);

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken) =>
        await _context.Set<T>().AddAsync(entity, cancellationToken);

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await Task.CompletedTask;
    }
    public virtual async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await Task.CompletedTask;
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AnyAsync(predicate);
    }
    #endregion
}