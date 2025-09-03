using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Entities;
using RealState.Domain.RealState.Properties.Errors;
using RealState.Domain.RealState.Properties.Repositories;

namespace RealState.Application.UseCase.Properties.Commands.Update;

public sealed class UpdatePropertyCommandHandler(IPropertyRepository propertyRepository)
    : ICommandHandler<UpdatePropertyCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
    {
        Property? property = await propertyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (property is null)
        {
            return Result.Failure<Guid>(PropertyErrors.PropertyNotFound(request.Id));
        }

        if (await propertyRepository.CodeInternalExistsForOtherAsync(request.Id, request.CodeInternal, cancellationToken))
        {
            return Result.Failure<Guid>(PropertyErrors.PropertyConflict_Code(request.CodeInternal));
        }

        property.Update(
            request.Name,
            request.Address,
            request.CodeInternal,
            request.Year
        );

        await propertyRepository.UpdateAsync(property);

        return property.Id;
    }
}