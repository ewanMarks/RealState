using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Infrastructure.Repository.RealState;
using RealState.Infrastructure.Repository.RealState.Owners;

namespace RealState.Infrastructure.Extension;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(RealStateRepository<>));

        services.AddScoped<IOwnerRepository, OwnerRepository>();
        return services;
    }
}
