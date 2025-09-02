using RealState.Domain.Abstractions.Entities;
using System.Linq.Expressions;

namespace RealState.Domain.Abstractions.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}
