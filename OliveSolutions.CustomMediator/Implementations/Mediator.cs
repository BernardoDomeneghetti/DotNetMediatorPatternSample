
using OliveSolutions.CustomMediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using OliveSolutions.CustomMediator.Abstractions.Handlers;
using OliveSolutions.CustomMediator.Abstractions.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OliveSolutions.CustomMediator.Implementations
{
    public class Mediator: IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest message, CancellationToken cancellationToken = default)
            where TRequest : IRequest
            where TResponse : IResponse
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(TRequest), typeof(TResponse));

            var handler = _serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"Handler for {typeof(TRequest).Name} not found.");

            var handleMethod = handler.GetType().GetMethod("HandleAsync")
                ?? throw new InvalidOperationException($"HandleAsync method not found on handler for {typeof(TRequest).Name}.");

            var response = handleMethod.Invoke(handler, new object[] { message, cancellationToken })
                ?? throw new InvalidOperationException($"HandleAsync method not found on handler for {typeof(TRequest).Name}.");

            return await (Task<TResponse>)response;
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(typeof(TNotification), typeof(IResponse));

            var handlers = _serviceProvider.GetServices(handlerType)
                ?? throw new InvalidOperationException($"Handler for {typeof(TNotification).Name} not found.");

            foreach (var handler in handlers)
            {
                if (handler == null) throw new InvalidOperationException($"Handler for {typeof(TNotification).Name} not found.");

                var handleMethod = handler.GetType().GetMethod("HandleAsync")
                    ?? throw new InvalidOperationException($"HandleAsync method not found on handler for {typeof(TNotification).Name}.");

                var response = handleMethod.Invoke(handler, new object[] { notification, cancellationToken })
                    ?? throw new InvalidOperationException($"HandleAsync method not found on handler for {typeof(TNotification).Name}.");

                await (Task)response;
            }
        }
    }
}

