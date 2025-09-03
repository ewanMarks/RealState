using Mapster;
using RealState.Application.Common.Messaging;
using RealState.Application.UseCase.Properties.DTOs;
using RealState.Domain.Abstractions.Result;
using RealState.Domain.RealState.Properties.Repositories;
using RealState.Domain.RealState.Properties.ValueObjects;

namespace RealState.Application.UseCase.Properties.Queries.GetAll;

public sealed class GetAllPropertiesQueryHandler(IPropertyRepository propertyRepository)
    : IQueryHandler<GetAllPropertiesQuery, GetAllPropertiesResult>
{
    public async Task<Result<GetAllPropertiesResult>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
    {
        var filters = new PropertyFilters(
            request.IdOwner,
            request.Name,
            request.Address,
            request.CodeInternal,
            request.PriceMin,
            request.PriceMax,
            request.YearMin,
            request.YearMax,
            request.CreatedFrom,
            request.CreatedTo,
            request.Page,
            request.PageSize,
            request.SortBy,
            request.SortDir
        );

        var entities = await propertyRepository.GetListAsync(filters, cancellationToken);
        var total = await propertyRepository.CountAsync(filters, cancellationToken);

        var items = entities.Adapt<IReadOnlyList<PropertyListItemDto>>();

        var result = new GetAllPropertiesResult(items, total, request.Page, request.PageSize);
        return result;
    }
}