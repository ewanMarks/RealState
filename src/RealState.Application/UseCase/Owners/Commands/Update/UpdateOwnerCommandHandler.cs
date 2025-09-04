using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Errors;
using RealState.Domain.RealState.Owners.Repositories;

namespace RealState.Application.UseCase.Owners.Commands.Update;

/// <summary>
/// Handler del comando <see cref="UpdateOwnerCommand"/> encargado de actualizar los datos de un propietario.
/// </summary>
public sealed class UpdateOwnerCommandHandler(IOwnerRepository ownerRepository)
    : ICommandHandler<UpdateOwnerCommand, Guid>
{
    /// <summary>
    /// Maneja el comando de actualización de propietario.
    /// </summary>
    public async Task<Result<Guid>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        Owner? owner = await ownerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (owner is null)
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerNotFound(request.Id));
        }

        if (!string.Equals(owner.Name, request.Name, StringComparison.OrdinalIgnoreCase)
            && await ownerRepository.ExistsAsync(x => x.Name == request.Name))
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerConflict(request.Name));
        }

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (request.Birthday is not null && request.Birthday > today)
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerBirthdayInvalid(request.Birthday.Value));
        }

        // Adaptar datos del request a la entidad existente
        (request, owner).Adapt(owner);
        await ownerRepository.UpdateAsync(owner);

        return owner.Id;
    }
}
