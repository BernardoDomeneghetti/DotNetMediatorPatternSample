using MediatorPattern.Abstractions.Application.Dtos;
using MediatorPattern.Application.Abstractions.Dtos;

namespace MediatorPattern.Abstractions.Application.Services;

public interface IApplicationService<TCommand, TResponse>
    where TCommand : IRequest
    where TResponse : IResponse
{
    Task<TResponse> ExecuteAsync(TCommand command);
}
