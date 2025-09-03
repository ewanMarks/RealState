using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Properties.DTOs;
using RealState.Application.UseCase.Properties.Queries.GetAll;
using RealState.Contracts.Request.Properties.GetAll;
using RealState.Contracts.Response.Properties.GetAll;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Properties;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{Tags.Property}/{nameof(GetAll)}", async ([AsParameters] GetAllPropertiesRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        {
            GetAllPropertiesQuery query = request.Adapt<GetAllPropertiesQuery>();
            Result<GetAllPropertiesResult> result = await sender.Send(query, cancellationToken);
            return result.Match(value => Results.Ok(value.Adapt<GetAllPropertiesResponse>()), CustomResults.Problem);
        })
        .WithTags(Tags.Property)
        .RequireAuthorization();
    }
}
