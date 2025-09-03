using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Domain.RealState.Properties.Repositories;

public interface IPropertyImageRepository : IRepository<PropertyImage>
{
    Task<bool> ExistsSameFileAsync(Guid idProperty, string file, CancellationToken cancellationToken = default);
    Task<int> CountByPropertyAsync(Guid idProperty, CancellationToken cancellationToken = default);
}