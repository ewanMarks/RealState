using MediatR;
using Microsoft.Extensions.Logging;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Interfaces;
using RealState.Domain.Abstractions.Result;

namespace RealState.Application.Common.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork uow,
    ILogger<UnitOfWorkBehavior<TRequest, TResponse>> logger
) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        var response = await next();

        if (request is IBaseCommand)
        {
            if (IsSuccess(response))
            {
                await uow.SaveChangesAsync(ct);
                logger.LogDebug("UoW committed for {Request}", typeof(TRequest).Name);
            }
            else
            {
                logger.LogDebug("UoW skipped (failed result) for {Request}", typeof(TRequest).Name);
            }
        }

        return response;
    }

    private static bool IsSuccess(TResponse response) =>
        response switch
        {
            Result r => r.IsSuccess,
            _ when response?.GetType().IsGenericType == true &&
                    response.GetType().GetGenericTypeDefinition() == typeof(Result<>)
                => (bool)response.GetType().GetProperty("IsSuccess")!.GetValue(response)!,
            _ => false
        };
}