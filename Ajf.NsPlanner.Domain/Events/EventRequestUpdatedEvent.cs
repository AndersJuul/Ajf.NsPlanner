using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class EventRequestUpdatedEvent : BaseDomainEvent
    {
        public EventRequest EventRequest { get; }

        public EventRequestUpdatedEvent(EventRequest eventRequest)
        {
            EventRequest = eventRequest;
        }
    }
}