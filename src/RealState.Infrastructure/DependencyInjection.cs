using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Infrastructure.Extension;

namespace RealState.Infrastructure;

/// <summary>
/// Métodos de extensión para registrar y utilizar la capa de infraestructura en el proyecto RealState.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registra los servicios de infraestructura en el contenedor de dependencias.
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSecurity(configuration);
        services.AddPersistence(configuration);
        services.AddRepositories(configuration);
        return services;
    }

    /// <summary>
    /// Ejecuta los seeders configurados en la infraestructura.
    /// </summary>
    public static async Task UseInfrastructure(this IServiceProvider serviceProvider)
    {
        await serviceProvider.RunSeedersAsync();
    }
}
