using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class PeriodDeletedEvent : BaseDomainEvent
    {
        public Period Period { get; }

        public PeriodDeletedEvent(Period period)
        {
            Period = period;
        }
    }
}