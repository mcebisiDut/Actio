using System;
using System.Threading.Tasks;
using Actio.Api.IRepositories;
using Actio.Api.Models;
using Actio.Common.Events;
using Actio.Common.IEvents;

namespace Actio.Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IUserRepository _userRepository;

        public UserCreatedHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(UserCreated @event)
        {
            await _userRepository.AddAsync(new User
            {
                Id = @event.Id,
                Email = @event.Email,
                Name = @event.Name,
                Password = @event.Password,
                Salt = @event.Salt,
                CreatedAt = @event.CreatedAt
            });
            Console.WriteLine($"User created: {@event.Email}");
        }
    }
}