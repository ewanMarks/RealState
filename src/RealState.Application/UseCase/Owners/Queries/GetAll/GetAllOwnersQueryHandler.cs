using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Application.UseCase.Owners.DTOs;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Owners.Repositories;
using RealState.Domain.RealState.Owners.ValueObjects;

namespace RealState.Application.UseCase.Owners.Queries.GetAll;

public sealed class GetAllOwnersQueryHandler(IOwnerRepository ownerRepository)
    : IQueryHandler<GetAllOwnersQuery, GetAllOwnersResult>
{
    public async Task<Result<GetAllOwnersResult>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
    {
        var filters = new OwnerFilters(
            request.Name,
            request.Address,
            request.BirthdayMin,
            request.BirthdayMax,
            request.CreatedFrom,
            request.CreatedTo,
            request.Page,
            request.PageSize,
            request.SortBy,
            request.SortDir
        );

        var entities = await ownerRepository.GetListAsync(filters, cancellationToken);
        var total = await ownerRepository.CountAsync(filters, cancellationToken);

        var items = entities.Adapt<IReadOnlyList<OwnerListItemDto>>();

        var result = new GetAllOwnersResult(items, total, request.Page, request.PageSize);
        return result;
    }
}
