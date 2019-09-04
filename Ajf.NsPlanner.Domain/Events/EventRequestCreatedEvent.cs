using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class EventRequestCreatedEvent : BaseDomainEvent
    {
        public EventRequest EventRequest { get; }

        public EventRequestCreatedEvent(EventRequest eventRequest)
        {
            EventRequest = eventRequest;
        }
    }
}