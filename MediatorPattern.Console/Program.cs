
using Microsoft.Extensions.DependencyInjection;
using MediatorPattern.Abstractions.Application.Services;
using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Extensions;
using MediatorPattern.Application.Responses;
using MediatorPattern.Infrastructure.Extensions;

namespace MediatorPattern.Console;

internal class Program
{
    private static readonly IServiceCollection services = new ServiceCollection();
    private static IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse> applicationService;
    private static void ConfigureServices()
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        var serviceProvider = services.BuildServiceProvider();
        applicationService = serviceProvider.GetRequiredService<IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>>();
    }
    private static void Main(string[] args)
    {
        ConfigureServices();
        applicationService.ExecuteAsync(new UpdateProductStorageCommand
        {
            ProductId = 1,
            MovementAmount = 10,
            MovementType = Domain.Enums.StorageMovementType.In,
            MovementDescription = "Adding stock to product"
        }).GetAwaiter().GetResult();

        
    }
}