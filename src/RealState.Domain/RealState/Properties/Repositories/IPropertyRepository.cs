using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.ValueObjects;

namespace RealState.Domain.RealState.Properties.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    Task<bool> CodeInternalExistsAsync(string codeInternal, CancellationToken cancellationToken = default);
    Task<bool> CodeInternalExistsForOtherAsync(Guid idProperty, string codeInternal, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Property>> GetListAsync(PropertyFilters filters, CancellationToken cancellationToken = default);
    Task<int> CountAsync(PropertyFilters filters, CancellationToken cancellationToken = default);
}