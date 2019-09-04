using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class AssignmentUpdatedEvent : BaseDomainEvent
    {
        public Assignment Assignment { get; }

        public AssignmentUpdatedEvent(Assignment assignment)
        {
            Assignment = assignment;
        }
    }
}