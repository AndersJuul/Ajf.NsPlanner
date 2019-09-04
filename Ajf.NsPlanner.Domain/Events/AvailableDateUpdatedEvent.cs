using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class AvailableDateUpdatedEvent : BaseDomainEvent
    {
        public AvailableDate AvailableDate { get; }

        public AvailableDateUpdatedEvent(AvailableDate availableDate)
        {
            AvailableDate = availableDate;
        }
    }
}