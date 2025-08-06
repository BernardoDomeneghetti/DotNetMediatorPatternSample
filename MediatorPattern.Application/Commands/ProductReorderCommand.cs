using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace MediatorPattern.Application.Commands;

public class ProductReorderCommand : IRequest
{
    public int ProductId { get; set; }
    public decimal Amount { get; set; }
}
