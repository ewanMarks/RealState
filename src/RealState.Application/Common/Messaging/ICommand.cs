using MediatR;
using RealState.Domain.Abstractions.Result;

namespace RealState.Application.Common.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;