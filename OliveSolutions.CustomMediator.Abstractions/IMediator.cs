using System.Threading;
using System.Threading.Tasks;
using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace OliveSolutions.CustomMediator.Abstractions
{
    public interface IMediator
    {
        Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest
            where TResponse : IResponse;

        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification;
    }
}

