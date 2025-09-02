using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealState.Api.Endpoints.Resources;
using RealState.Api.Extensions;
using RealState.Api.Infrastructure;
using RealState.Application.UseCase.Owners.Commands.Update;
using RealState.Contracts.Request.Owners.Update;
using RealState.Domain.Abstractions.Result;

namespace RealState.Api.Endpoints.RealState.Owners;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut($"{Tags.Owner}/{nameof(Update)}", async ([FromBody] UpdateOwnerRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        {
            UpdateOwnerCommand command = request.Adapt<UpdateOwnerCommand>();

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Owner)
        .RequireAuthorization();
    }
}
