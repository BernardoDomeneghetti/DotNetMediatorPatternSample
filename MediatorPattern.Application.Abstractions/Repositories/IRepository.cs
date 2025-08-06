using MediatorPattern.Domain.Abstractions;


namespace MediatorPattern.Application.Abstractions.Repositories;

public interface IRepository<in TEntity> where TEntity : class, IEntity
{
    Task AddAsync(TEntity entity);
}
