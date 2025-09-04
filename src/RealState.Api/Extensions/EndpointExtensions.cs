using Microsoft.Extensions.DependencyInjection.Extensions;
using RealState.Api.Endpoints;
using System.Reflection;

namespace RealState.Api.Extensions;

/// <summary>
/// Métodos de extensión para registrar y mapear endpoints de Minimal API
/// de forma automática.
/// </summary>
public static class EndpointExtensions
{
    /// <summary>
    /// Registra en el contenedor de dependencias todos los endpoints
    /// que implementen la interfaz <see cref="IEndpoint"/> dentro del ensamblado especificado.
    /// </summary>
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] serviceDescriptors = [.. assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))];

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    /// <summary>
    /// Mapea en el pipeline todos los endpoints registrados en DI
    /// que implementen <see cref="IEndpoint"/>.
    /// </summary>
    public static IApplicationBuilder MapEndpoints(
        this WebApplication app,
        RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }

    /// <summary>
    /// Requiere autorización asociada a un permiso específico sobre un endpoint.
    /// </summary>
    public static RouteHandlerBuilder HasPermission(this RouteHandlerBuilder app, string permission)
    {
        return app.RequireAuthorization(permission);
    }
}