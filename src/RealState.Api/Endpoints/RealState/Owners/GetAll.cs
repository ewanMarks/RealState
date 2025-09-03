using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Owners.DTOs;
using RealState.Application.UseCase.Owners.Queries.GetAll;
using RealState.Contracts.Request.Owners.GetAll;
using RealState.Contracts.Response.Owners.GetAll;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Owners;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Tags.Owner}/{nameof(GetAll)}", async ([AsParameters] GetAllOwnersRequest request, [FromServices] ISender sender, CancellationToken ct) =>
        {
            GetAllOwnersQuery query = request.Adapt<GetAllOwnersQuery>();
            Result<GetAllOwnersResult> result = await sender.Send(query, ct);
            return result.Match(value => Results.Ok(value.Adapt<GetAllOwnersResponse>()), CustomResults.Problem);
        })
        .WithTags(Tags.Owner)
        .RequireAuthorization();
    }
}