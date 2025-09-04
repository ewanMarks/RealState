using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Errors;
using RealState.Domain.RealState.Properties.Repositories;

namespace RealState.Application.UseCase.ChangePrice.Commands.Change;

/// <summary>
/// Handler del comando <see cref="ChangePropertyPriceCommand"/> encargado de actualizar
/// el precio de una propiedad y registrar un <see cref="PropertyTrace"/> asociado.
/// </summary>
public sealed class ChangePropertyPriceCommandHandler(IPropertyRepository propertyRepository, IPropertyTraceRepository propertyTraceRepository)
    : ICommandHandler<ChangePropertyPriceCommand, Guid>
{
    /// <summary>
    /// Maneja el comando de cambio de precio de una propiedad.
    /// </summary>
    public async Task<Result<Guid>> Handle(ChangePropertyPriceCommand request, CancellationToken cancellationToken)
    {
        var property = await propertyRepository.GetByIdAsync(request.IdProperty, cancellationToken);
        if (property is null)
        {
            return Result.Failure<Guid>(PropertyTraceErrors.PropertyNotFound(request.IdProperty));
        }

        if (request.NewPrice <= 0)
        {
            return Result.Failure<Guid>(PropertyTraceErrors.PropertyPriceInvalid(request.NewPrice));
        }

        // Actualizar precio
        property.SetPrice(request.NewPrice);
        await propertyRepository.UpdateAsync(property);

        // Crear traza de auditoría
        var traceName = string.IsNullOrWhiteSpace(request.Name) ? "Change Price" : request.Name!;
        var tax = request.Tax ?? 0m;

        var trace = new PropertyTrace(
            property.Id,
            DateTime.UtcNow,
            traceName,
            request.NewPrice,
            tax
        );

        await propertyTraceRepository.AddAsync(trace, cancellationToken);

        return trace.Id;
    }
}