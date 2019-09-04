using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class PeriodCreatedEvent : BaseDomainEvent
    {
        public PeriodCreatedEvent(Period period)
        {
            Period = period;
        }

        public Period Period { get; }
    }
}