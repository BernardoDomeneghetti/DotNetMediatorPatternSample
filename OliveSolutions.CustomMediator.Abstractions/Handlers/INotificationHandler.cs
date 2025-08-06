using System.Threading.Tasks;
using OliveSolutions.CustomMediator.Abstractions.Dtos;

namespace OliveSolutions.CustomMediator.Abstractions.Handlers
{
    public interface INotificationHandler<in TNotification> where TNotification : INotification
    {
        Task HandleAsync(TNotification notification);
    }
}

