using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Notifications;
using MediatorPattern.Application.Responses;
using OliveSolutions.CustomMediator.Abstractions.Handlers;

namespace MediatorPattern.Application.Services;

public class OperationLoggerService: 
    IRequestHandler<OperationLogCommand, OperationLogResponse>,
    INotificationHandler<ProductStorageUpdatedNotification>
{
    public async Task<OperationLogResponse> HandleAsync(OperationLogCommand command, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100); 
        Console.WriteLine(command.LogMessage);

        return new OperationLogResponse("Operation logged successfully.");
    }

    public async Task HandleNotificationAsync(ProductStorageUpdatedNotification notification, CancellationToken cancellationToken = default)
    {
        var operationLogCommand = new OperationLogCommand
        {
            LogMessage = $"Product storage updated: ProductId={notification.ProductId}, MovementType={notification.MovementType}, Amount={notification.MovementAmount}"
        };
        await HandleAsync(operationLogCommand);
    }
}
