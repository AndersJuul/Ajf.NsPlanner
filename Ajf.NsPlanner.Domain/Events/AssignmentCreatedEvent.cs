using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class AssignmentCreatedEvent : BaseDomainEvent
    {
        public Assignment Assignment { get; }

        public AssignmentCreatedEvent(Assignment assignment)
        {
            Assignment = assignment;
        }
    }
}