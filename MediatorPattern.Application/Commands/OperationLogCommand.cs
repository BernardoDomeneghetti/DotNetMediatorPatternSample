using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Commands;

public record class OperationLogCommand : IRequest
{
    public string LogMessage { get; set; }
}
