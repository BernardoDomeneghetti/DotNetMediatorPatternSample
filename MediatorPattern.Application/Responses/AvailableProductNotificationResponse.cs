using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Responses;

public record class AvailableProductNotificationResponse : IResponse
{
    public string Message { get; set; }

    public AvailableProductNotificationResponse(string message) => Message = message;
}
