using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Errors;
using RealState.Domain.RealState.Owners.Repositories;

namespace RealState.Application.UseCase.Owners.Commands.Create;

/// <summary>
/// Handler del comando <see cref="CreateOwnerCommand"/> encargado de crear un nuevo propietario.
/// </summary>
public sealed class CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
    : ICommandHandler<CreateOwnerCommand, Guid>
{
    /// <summary>
    /// Maneja el comando de creación de propietario.
    /// </summary>
    public async Task<Result<Guid>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var normalized = request.Name.Trim();

        if (await ownerRepository.ExistsAsync(x => x.Name.ToLower() == normalized.ToLower()))
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerConflict(request.Name));
        }

        Owner owner = request.Adapt<Owner>();
        await ownerRepository.AddAsync(owner, cancellationToken);

        return owner.Id;
    }
}