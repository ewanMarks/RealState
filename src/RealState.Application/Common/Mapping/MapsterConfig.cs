using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RealState.Application.Common.Mapping;

public static class MapsterConfig
{
    public static IServiceCollection AddMapsterConfigs(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<MapsterMapper.IMapper, MapsterMapper.ServiceMapper>();
        return services;
    }
}