using MediatR;
using RealState.Application.Common.Messaging;
using RealState.Domain.Abstractions.Interfaces;

namespace RealState.Application.Common.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        if (request is ICommand && response is IResult { IsSuccess: true })
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return response;
    }
}