using Actio.Common.IEvents;

namespace Actio.Common.Events
{
    public class CreatedUserFailure : IFailureEvent
    {
        public string Email { get; }
        public string Message { get; }
        public string Code { get; }

        public CreatedUserFailure()
        {
        }

        public CreatedUserFailure(string email, string message, string code)
        {
            Email = email;
            Message = message;
            Code = code;
        }
    }
}