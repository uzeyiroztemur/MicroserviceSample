using Microservice.Core.Amqp.Commands;
using Microservice.Core.Amqp.Events;

namespace Microservice.Core.Amqp.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }
}