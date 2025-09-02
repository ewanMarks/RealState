using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Errors;
using RealState.Domain.RealState.Owners.Repositories;

namespace RealState.Application.UseCase.Owners.Commands.Delete;

public sealed class DeleteOwnerCommandHandler(IOwnerRepository ownerRepository)
    : ICommandHandler<DeleteOwnerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        Owner owner = await ownerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (owner is null)
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerNotFound(request.Id));
        }

        if (await ownerRepository.HasLinkedPropertiesAsync(owner.Id,cancellationToken))
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerHasLinkedProperties(owner.Id));
        }

        await ownerRepository.RemoveAsync(owner);
        return owner.Id;
    }
}