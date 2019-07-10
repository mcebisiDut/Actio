using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Common.ICommands;
using Authentication.IServices;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Authentication.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IBusClient busClient,IUserService userService,ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating User: '{command.Email}' '{command.Name}'");
            try
            {
                await _userService.RegisterAsync(command.Email,command.Password,command.Name);
                await _busClient.PublishAsync(new UserCreated(command.Email,command.Name));

                return;
            }
            catch (ActioException exception)
            {
                await _busClient.PublishAsync(new CreateUserFailure(command.Email,exception.Message,exception.Code));
                _logger.LogError(exception.Message);
            }
        }
    }
}