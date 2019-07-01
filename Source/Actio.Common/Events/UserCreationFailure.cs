using Actio.Common.IEvents;

namespace Actio.Common.Events
{
    public class UserCreationFailure : IFailedEvent
    {
        public string Email { get; }
        public string Message { get; }

        public string Code { get; }
        protected UserCreationFailure()
        {
        }
        public UserCreationFailure(string email, string message, string code)
        {
            Email = email;
            Message = message;
            Code = code;
        }
    }
}