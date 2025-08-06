using MediatorPattern.Domain.Enums;
using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Notifications;

public record class ProductStorageUpdatedNotification: INotification
{
    public int ProductId { get; set; }
    public decimal MovementAmount { get; set; }
    public StorageMovementType MovementType { get; set; }
    public string MovementDescription { get; set; }
}
