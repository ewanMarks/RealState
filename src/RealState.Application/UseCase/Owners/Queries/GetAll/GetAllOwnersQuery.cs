using RealState.Application.Common.Messaging;
using RealState.Application.UseCase.Owners.DTOs;

namespace RealState.Application.UseCase.Owners.Queries.GetAll;

public sealed record GetAllOwnersQuery(
    string? Name,
    string? Address,
    DateOnly? BirthdayMin,
    DateOnly? BirthdayMax,
    DateTime? CreatedFrom,
    DateTime? CreatedTo,
    int Page,
    int PageSize,
    string? SortBy,
    string? SortDir) : IQuery<GetAllOwnersResult>;