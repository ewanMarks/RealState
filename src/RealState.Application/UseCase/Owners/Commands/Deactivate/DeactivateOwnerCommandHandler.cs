using RealState.Application.Common.Messaging;
using RealState.Application.UseCase.Owners.Commands.Desactivate;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Errors;
using RealState.Domain.RealState.Owners.Repositories;

namespace RealState.Application.UseCase.Owners.Commands.Deactivate;

/// <summary>
/// Handler del comando <see cref="DeactivateOwnerCommand"/> encargado de desactivar un propietario.
/// </summary>
public sealed class DeactivateOwnerCommandHandler(IOwnerRepository ownerRepository)
    : ICommandHandler<DeactivateOwnerCommand, Guid>
{
    /// <summary>
    /// Maneja el comando de desactivación de un propietario.
    /// </summary>
    public async Task<Result<Guid>> Handle(DeactivateOwnerCommand request, CancellationToken cancellationToken)
    {
        Owner? owner = await ownerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (owner is null)
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerNotFound(request.Id));
        }

        if (await ownerRepository.HasLinkedPropertiesAsync(owner.Id, cancellationToken))
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerHasLinkedProperties(owner.Id));
        }

        if (!owner.IsActive)
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerAlreadyInactive(owner.Id));
        }

        // Desactivar propietario (soft delete)
        owner.Deactivate();
        await ownerRepository.UpdateAsync(owner);

        return owner.Id;
    }
}