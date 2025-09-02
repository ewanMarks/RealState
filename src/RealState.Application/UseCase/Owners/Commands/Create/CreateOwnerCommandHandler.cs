using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Owners.Errors;
using RealState.Domain.RealState.Owners.Repositories;

namespace RealState.Application.UseCase.Owners.Commands.Create;

public sealed class CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
    : ICommandHandler<CreateOwnerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {

        if (await ownerRepository.ExistsAsync(x => x.Name == request.Name))
        {
            return Result.Failure<Guid>(OwnerErrors.OwnerConflict(request.Name));
        }

        Owner owner = request.Adapt<Owner>();
        await ownerRepository.AddAsync(owner, cancellationToken);

        return owner.Id;
    }
}