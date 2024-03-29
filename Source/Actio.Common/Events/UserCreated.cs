using System;
using Actio.Common.IEvents;

namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }

        protected UserCreated()
        {
        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}