

using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Commands;

public record class AvailableProductNotificationCommand : IRequest
{
    public int ProductId { get; set; }
}
