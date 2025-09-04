using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Errors;
using RealState.Domain.RealState.Properties.Repositories;

namespace RealState.Application.UseCase.PropertyImages.Commands;

/// <summary>
/// Handler para el comando <see cref="AddPropertyImageCommand"/>.
/// </summary>
public sealed class AddPropertyImageCommandHandler(IPropertyImageRepository propertyImageRepository, IPropertyRepository propertyRepository)
    : ICommandHandler<AddPropertyImageCommand, Guid>
{
    /// <summary>
    /// Maneja la ejecución del comando <see cref="AddPropertyImageCommand"/>.
    /// </summary>
    public async Task<Result<Guid>> Handle(AddPropertyImageCommand request, CancellationToken cancellationToken)
    {
        if (!await propertyRepository.ExistsAsync(p => p.Id == request.IdProperty))
        {
            return Result.Failure<Guid>(PropertyImageErrors.PropertyNotFound(request.IdProperty));
        }

        if (await propertyImageRepository.ExistsSameFileAsync(request.IdProperty, request.File, cancellationToken))
        {
            return Result.Failure<Guid>(PropertyImageErrors.PropertyImageConflict(request.File));
        }

        PropertyImage image = request.Adapt<PropertyImage>();
        await propertyImageRepository.AddAsync(image, cancellationToken);

        return image.Id;
    }
}