using Microsoft.Extensions.DependencyInjection;
using MediatorParttern.Infrastructure.Repositories;
using MediatorPattern.Application.Abstractions.Repositories;
using MediatorPattern.Domain.Models;

namespace MediatorPattern.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<ProductStorage>, ProductStorageRepository>();
        return services;
    }
}
