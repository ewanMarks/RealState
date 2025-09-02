using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Owners.Commands.Create;
using RealState.Contracts.Request.Owners.Create;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Owners;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost($"{Tags.Owner}/{nameof(Create)}", async ([FromBody] CreateOwnerRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        {
            CreateOwnerCommand command = request.Adapt<CreateOwnerCommand>();
            Result<Guid> result = await sender.Send(command, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Owner)
        .RequireAuthorization();
    }
}