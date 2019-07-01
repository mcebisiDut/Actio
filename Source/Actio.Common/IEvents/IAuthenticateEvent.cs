using System;

namespace Actio.Common.IEvents
{
    public interface IAuthenticateEvent : IEvent
    {
        Guid UserId { get; }
    }
}