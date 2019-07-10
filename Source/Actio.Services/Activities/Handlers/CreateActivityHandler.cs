using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Common.ICommands;
using Activities.IServices;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        private readonly ILogger<CreateActivityHandler> _logger;

        public CreateActivityHandler(IBusClient busClient, IActivityService activityService, ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }
        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: {command.Category} {command.Name}");
            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Name, command.Category, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));

                return;
            }
            catch (ActioException exception)
            {
                await _busClient.PublishAsync(new CreateActivityFailure(command.Id,exception.Code,exception.Message));
                _logger.LogError(exception.Message);
            }
        }
    }
}