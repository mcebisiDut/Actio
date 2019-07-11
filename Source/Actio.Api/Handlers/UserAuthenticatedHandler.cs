using System;
using System.Threading.Tasks;
using Actio.Common.Events;
using Actio.Common.IEvents;

namespace Actio.Api.Handlers
{
    public class UserAuthenticatedHandler : IEventHandler<UserAuthenticated>
    {
        public async Task HandleAsync(UserAuthenticated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User created: {@event.Email}");
        }
    }
}