using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class CounselorCreatedEvent : BaseDomainEvent
    {
        public Counselor Counselor { get; }

        public CounselorCreatedEvent(Counselor counselor)
        {
            Counselor = counselor;
        }
    }
}