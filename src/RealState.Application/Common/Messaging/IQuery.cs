using MediatR;
using RealState.Domain.Abstractions.Result;

namespace RealState.Application.Common.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;