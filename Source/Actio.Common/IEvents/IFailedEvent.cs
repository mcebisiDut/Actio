namespace Actio.Common.IEvents
{
    public interface IFailedEvent : IEvent
    {
        string Message { get; }
        string Code { get; }
    }
}