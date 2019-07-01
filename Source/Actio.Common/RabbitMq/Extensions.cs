using System.Reflection;
using System.Threading.Tasks;
using Actio.Common.ICommands;
using Actio.Common.IEvents;
using RawRabbit;
using RawRabbit.Pipe;

namespace Actio.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
            ctx => ctx.UseConsumerConfiguration(config =>
                config.FromDeclaredQueue(queue => queue.WithName(GetQueueName<TCommand>()))));


        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
            ctx => ctx.UseConsumerConfiguration(config =>
                config.FromDeclaredQueue(queue => queue.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}