
using MediatorPattern.Application.Abstractions.Mappers;
using MediatorPattern.Application.Abstractions.Repositories;
using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Notifications;
using MediatorPattern.Application.Responses;
using MediatorPattern.Domain.Models;
using OliveSolutions.CustomMediator.Abstractions;
using OliveSolutions.CustomMediator.Abstractions.Handlers;

namespace MediatorPattern.Application.Handlers;

public class StorageAmountUpdateHandler
    (
        IRepository<ProductStorage> productStorageRepository,
        IMapper<UpdateProductStorageCommand, ProductStorage> mapper,
        IMediator mediator
    ) 
    : IRequestHandler<UpdateProductStorageCommand, UpdateStorageProductResponse>
{

    public async Task<UpdateStorageProductResponse> HandleAsync(UpdateProductStorageCommand request, CancellationToken cancellationToken = default)
    {
        var productStorage = mapper.Map(request);
        await productStorageRepository.AddAsync(productStorage);
        await mediator.PublishAsync(
            new ProductStorageUpdatedNotification
            {
                ProductId = productStorage.ProductId,
                MovementType = request.MovementType,
                MovementAmount = request.MovementAmount
            }
        );
        return new UpdateStorageProductResponse("Successfully updated the product storage.");
    }
}
