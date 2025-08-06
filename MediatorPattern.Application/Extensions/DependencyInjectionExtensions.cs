using Microsoft.Extensions.DependencyInjection;
using MediatorPattern.Abstractions.Application.Services;
using MediatorPattern.Application.Abstractions.Mappers;
using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Mappers;
using MediatorPattern.Application.Responses;
using MediatorPattern.Application.Services;
using MediatorPattern.Domain.Models;

namespace MediatorPattern.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>, StorageAmountUpdateService>();
        services.AddScoped<IMapper<UpdateProductStorageCommand, ProductStorage>, UpdateProductStorageCommandToProductStorageMapper>();

        return services;
    }
}
