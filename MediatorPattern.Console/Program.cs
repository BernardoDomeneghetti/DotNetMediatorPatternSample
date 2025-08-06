
using Microsoft.Extensions.DependencyInjection;
using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Extensions;
using MediatorPattern.Application.Responses;
using MediatorPattern.Infrastructure.Extensions;
using OliveSolutions.CustomMediator.Abstractions.Handlers;
using OliveSolutions.CustomMediator.Abstractions;
using MediatorPattern.Domain.Enums;

namespace MediatorPattern.Console;

internal class Program
{
    private static readonly IServiceCollection services = new ServiceCollection();
    private static IMediator mediator;
    private static void ConfigureServices()
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        var serviceProvider = services.BuildServiceProvider();
        mediator = serviceProvider.GetService<IMediator>();
    }
    private static void Main(string[] args)
    {
        ConfigureServices();
        mediator.SendAsync<UpdateProductStorageCommand, UpdateStorageProductResponse>(new UpdateProductStorageCommand
        {
            ProductId = 1,
            MovementAmount = 10,
            MovementType = StorageMovementType.In,
            MovementDescription = "Adding stock to product"
        }).GetAwaiter().GetResult();

        mediator.SendAsync<UpdateProductStorageCommand, UpdateStorageProductResponse>(new UpdateProductStorageCommand
        {
            ProductId = 1,
            MovementAmount = 10,
            MovementType = StorageMovementType.Out,
            MovementDescription = "Removing stock from product"
        }).GetAwaiter().GetResult();
    }
}