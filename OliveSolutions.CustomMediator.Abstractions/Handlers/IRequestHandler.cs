using System.Threading.Tasks;
using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace OliveSolutions.CustomMediator.Abstractions.Handlers
{
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}

