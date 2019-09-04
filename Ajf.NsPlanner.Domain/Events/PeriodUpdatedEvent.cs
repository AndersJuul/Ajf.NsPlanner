using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class PeriodUpdatedEvent : BaseDomainEvent
    {
        public Period Period { get; }

        public PeriodUpdatedEvent(Period period)
        {
            Period = period;
        }
    }
}