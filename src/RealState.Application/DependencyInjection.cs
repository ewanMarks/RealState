using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RealState.Application.Common.Behaviors;
using RealState.Application.Common.Mapping;
using System.Reflection;

namespace RealState.Application;

/// <summary>
/// Punto de extensión para registrar los servicios de la capa Application.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registra en el contenedor de dependencias todos los servicios propios de la capa Application.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMapsterConfigs();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

        return services;
    }
}