using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class SchoolEvent : AggregateRoot
    {
        public string Name { get; set; }
    }
}
