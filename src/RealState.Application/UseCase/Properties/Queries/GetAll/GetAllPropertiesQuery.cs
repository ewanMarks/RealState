using RealState.Application.Common.Messaging;
using RealState.Application.UseCase.Properties.DTOs;

namespace RealState.Application.UseCase.Properties.Queries.GetAll;

public sealed record GetAllPropertiesQuery(
    Guid? IdOwner,
    string? Name,
    string? Address,
    string? CodeInternal,
    decimal? PriceMin,
    decimal? PriceMax,
    int? YearMin,
    int? YearMax,
    DateTime? CreatedFrom,
    DateTime? CreatedTo,
    int Page,
    int PageSize,
    string? SortBy,
    string? SortDir
) : IQuery<GetAllPropertiesResult>;