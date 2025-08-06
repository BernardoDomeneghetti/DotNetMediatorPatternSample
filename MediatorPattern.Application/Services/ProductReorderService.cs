using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Notifications;
using MediatorPattern.Application.Responses;
using MediatorPattern.Domain.Enums;
using OliveSolutions.CustomMediator.Abstractions.Handlers;

namespace MediatorPattern.Application.Services;

public class ProductReorderService : 
    IRequestHandler<ProductReorderCommand, ProductReorderResponse>,
    INotificationHandler<ProductStorageUpdatedNotification>
{
    public async Task<ProductReorderResponse> HandleAsync(ProductReorderCommand request, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            Console.WriteLine($"Reordering product with ID: {request.ProductId}, Amount: {request.Amount}");
            return new ProductReorderResponse($"Product with ID: {request.ProductId} reordered successfully.");
        });
    }

    public async Task HandleNotificationAsync(ProductStorageUpdatedNotification notification, CancellationToken cancellationToken = default)
    {
        if (notification.MovementType == StorageMovementType.Out)
        {
            var productReorderCommand = new ProductReorderCommand
            {
                ProductId = notification.ProductId,
                Amount = notification.MovementAmount
            };

            await HandleAsync(productReorderCommand);
        }
    }
}
