namespace Actio.Common.IEvents
{
    public interface IFailureEvent : IEvent
    {
        string Message { get; }
        string Code { get; }
    }
}