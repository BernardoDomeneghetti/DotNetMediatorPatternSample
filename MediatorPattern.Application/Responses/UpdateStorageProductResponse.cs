using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Responses;

public record class UpdateStorageProductResponse: IResponse
{
    public UpdateStorageProductResponse(string message)
    {
        Message = message;
    }

    public string Message { get; set; } = string.Empty;
}
