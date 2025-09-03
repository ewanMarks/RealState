using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Errors;
using RealState.Domain.RealState.Properties.Repositories;

namespace RealState.Application.UseCase.Properties.Commands.Create;

public sealed class CreatePropertyBuildingCommandHandler(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository)
    : ICommandHandler<CreatePropertyBuildingCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreatePropertyBuildingCommand request, CancellationToken cancellationToken)
    {
        if (!await ownerRepository.ExistsAsync(o => o.Id == request.IdOwner))
        {
            return Result.Failure<Guid>(PropertyErrors.OwnerNotFound(request.IdOwner));
        }

        if (await propertyRepository.CodeInternalExistsAsync(request.CodeInternal, cancellationToken))
        {
            return Result.Failure<Guid>(PropertyErrors.PropertyConflict_Code(request.CodeInternal));
        }

        Property property = request.Adapt<Property>();

        await propertyRepository.AddAsync(property, cancellationToken);

        return property.Id;
    }
}