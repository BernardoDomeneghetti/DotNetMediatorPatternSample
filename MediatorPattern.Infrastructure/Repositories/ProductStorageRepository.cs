using MediatorPattern.Application.Abstractions.Repositories;
using MediatorPattern.Domain.Models;

namespace MediatorParttern.Infrastructure.Repositories;

public class ProductStorageRepository: IRepository<ProductStorage>
{
    private readonly List<ProductStorage> _storage = [];
    public IEnumerable<ProductStorage> GetAll()
    {
        return _storage;
    }

    public async Task AddAsync(ProductStorage entity)
    {
        await Task.Delay(100); // Simulate async operation
        _storage.Add(entity);
    }
}
