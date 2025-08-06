using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Notifications;
using MediatorPattern.Application.Responses;
using MediatorPattern.Domain.Enums;
using OliveSolutions.CustomMediator.Abstractions.Handlers;

namespace MediatorPattern.Application.Services;

public class AvailableProductNotificationService : 
    IRequestHandler<AvailableProductNotificationCommand, AvailableProductNotificationResponse>,
    INotificationHandler<ProductStorageUpdatedNotification>
{

    public async Task<AvailableProductNotificationResponse> HandleAsync(AvailableProductNotificationCommand command, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100); // Simulate some async operation
        Console.WriteLine($"The product {command.ProductId} is now available for purchase.");

        return new AvailableProductNotificationResponse($"Notification sent for product: {command.ProductId}");
    }

    public async Task HandleNotificationAsync(ProductStorageUpdatedNotification notification, CancellationToken cancellationToken = default)
    {
        if (notification.MovementType == StorageMovementType.In)
        {
            var notificationCommand = new AvailableProductNotificationCommand
            {
                ProductId = notification.ProductId
            };
            await HandleAsync(notificationCommand);
        }
    }
}