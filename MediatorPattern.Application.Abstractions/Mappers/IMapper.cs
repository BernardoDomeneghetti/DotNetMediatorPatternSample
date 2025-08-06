namespace MediatorPattern.Application.Abstractions.Mappers;

public interface IMapper<in TSource, out TDestination>
    where TSource : class
    where TDestination : class
{
    TDestination Map(TSource source);
}
