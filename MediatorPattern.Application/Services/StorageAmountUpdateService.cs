using MediatorPattern.Abstractions.Application.Services;
using MediatorPattern.Application.Abstractions.Mappers;
using MediatorPattern.Application.Abstractions.Repositories;
using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Responses;
using MediatorPattern.Domain.Models;

namespace MediatorPattern.Application.Services;

public class StorageAmountUpdateService
    (
        IRepository<ProductStorage> productStorageRepository,
        IMapper<UpdateProductStorageCommand, ProductStorage> mapper
    ) 
    : IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>
{
    public async Task<UpdateStorageProductResponse> ExecuteAsync(UpdateProductStorageCommand command)
    {
        var productStorage = mapper.Map(command);
        await productStorageRepository.AddAsync(productStorage);
        return new UpdateStorageProductResponse("Successfully updated the product storage.");
    }
}
