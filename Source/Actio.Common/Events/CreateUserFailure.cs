using Actio.Common.IEvents;

namespace Actio.Common.Events
{
    public class CreateUserFailure : IFailureEvent
    {
        public string Email { get; }
        public string Message { get; }
        public string Code { get; }

        public CreateUserFailure()
        {
        }

        public CreateUserFailure(string email, string message, string code)
        {
            Email = email;
            Message = message;
            Code = code;
        }
    }
}