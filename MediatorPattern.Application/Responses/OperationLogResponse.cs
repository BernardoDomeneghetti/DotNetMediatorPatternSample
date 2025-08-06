using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Responses;

public class OperationLogResponse(string message) : IResponse
{
    public string Message { get; set; } = message;
}
