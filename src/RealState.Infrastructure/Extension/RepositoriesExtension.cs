using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Domain.RealState.Properties.Repositories;
using RealState.Domain.RealState.Users.Repositories;
using RealState.Infrastructure.Repository.RealState;
using RealState.Infrastructure.Repository.RealState.Owners;
using RealState.Infrastructure.Repository.RealState.Properties;
using RealState.Infrastructure.Repository.RealState.Users;

namespace RealState.Infrastructure.Extension;

/// <summary>
/// Métodos de extensión para registrar los repositorios en el contenedor de dependencias.
/// </summary>
public static class RepositoriesExtension
{
    /// <summary>
    /// Registra las implementaciones de repositorios concretos en la capa <c>Infrastructure</c>.
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(RealStateRepository<>));

        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
        services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
