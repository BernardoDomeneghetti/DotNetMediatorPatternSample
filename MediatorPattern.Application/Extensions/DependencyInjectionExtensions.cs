using Microsoft.Extensions.DependencyInjection;
using MediatorPattern.Application.Abstractions.Mappers;
using MediatorPattern.Application.Commands;
using MediatorPattern.Application.Mappers;
using MediatorPattern.Domain.Models;
using OliveSolutions.CustomMediator.Extensions;

namespace MediatorPattern.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddCustomMediator();
        services.AddScoped<IMapper<UpdateProductStorageCommand, ProductStorage>, UpdateProductStorageCommandToProductStorageMapper>();

        return services;
    }
}
