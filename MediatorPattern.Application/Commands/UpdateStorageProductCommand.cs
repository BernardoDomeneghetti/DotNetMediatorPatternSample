using MediatorPattern.Application.Abstractions.Dtos;
using MediatorPattern.Domain.Enums;

namespace MediatorPattern.Application.Commands;

public record class UpdateProductStorageCommand: IRequest
{
    public int ProductId { get; set; }
    public decimal MovementAmount { get; set; }
    public StorageMovementType MovementType { get; set; }
    public string MovementDescription { get; set; }
}
