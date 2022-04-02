using Microservice.Core.Entities;
using System;

namespace Microservice.Core.Amqp.Events
{
    public abstract class Event : IEvent
    {
        public DateTime TimeStamp { get; protected set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}