using System;
using Actio.Common.IEvents;

namespace Actio.Common.Events
{
    public class CreateActivityFailure : IFailureEvent
    {
        public Guid Id { get; }
        public string Message { get; }

        public string Code { get; }

        protected CreateActivityFailure()
        {
        }

        public CreateActivityFailure(Guid id, string message, string code)
        {
            Id = id;
            Message = message;
            Code = code;
        }
    }
}