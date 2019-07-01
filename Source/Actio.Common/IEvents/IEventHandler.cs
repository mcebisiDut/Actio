using System.Threading.Tasks;

namespace Actio.Common.IEvents
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}