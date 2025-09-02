using MediatR;
using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Entities;
using RealState.Domain.RealState.Properties.Entities;

namespace RealState.Application.UseCase.Propertiess.Commands.Create;

public sealed class CreatePropertyHandler(
    IRepository<Property> propertyRepository,
    IRepository<Owner> ownerRepository
) : IRequestHandler<CreatePropertyCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
