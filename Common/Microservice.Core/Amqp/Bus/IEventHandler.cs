using Microservice.Core.Amqp.Events;
using Microservice.Core.Entities;

namespace Microservice.Core.Amqp.Bus
{
    public interface IEventHandler<in TEvent> : IEvent where TEvent : Event
    {
        Task Handle(TEvent @event);
    }
}