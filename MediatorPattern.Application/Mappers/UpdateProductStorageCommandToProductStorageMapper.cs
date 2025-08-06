using MediatorPattern.Application.Abstractions.Mappers;
using MediatorPattern.Application.Commands;
using MediatorPattern.Domain.Models;

namespace MediatorPattern.Application.Mappers;

public class UpdateProductStorageCommandToProductStorageMapper:IMapper<UpdateProductStorageCommand, ProductStorage>
{
    public ProductStorage Map(UpdateProductStorageCommand source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return new ProductStorage
        {
            ProductId = source.ProductId,
            MovementAmount = source.MovementAmount,
            MovementType = source.MovementType,
            Description = source.MovementDescription
        };
    }
}
