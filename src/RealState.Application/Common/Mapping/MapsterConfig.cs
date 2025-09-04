using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RealState.Application.Common.Mapping;

/// <summary>
/// Configuración central de Mapster para la capa de aplicación.
/// </summary>
public static class MapsterConfig
{
    /// <summary>
    /// Registra la configuración de Mapster en el contenedor de dependencias.
    /// </summary>
    public static IServiceCollection AddMapsterConfigs(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<MapsterMapper.IMapper, MapsterMapper.ServiceMapper>();
        return services;
    }
}