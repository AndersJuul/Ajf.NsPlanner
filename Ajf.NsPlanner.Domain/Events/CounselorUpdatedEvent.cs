using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class CounselorUpdatedEvent : BaseDomainEvent
    {
        public Counselor Counselor { get; }

        public CounselorUpdatedEvent(Counselor counselor)
        {
            Counselor = counselor;
        }
    }
}