using RealState.Domain.Abstractions.Result;
using Error = RealState.Domain.Abstractions.Result.Error;

namespace RealState.Domain.Abstractions.Interfaces;

public interface IResult
{
    bool IsSuccess { get; }
    bool IsFailure { get; }
    Error? Error { get; }
    IReadOnlyList<ValidationError>? ValidationErrors { get; }
}