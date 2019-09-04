using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Domain.Queries
{
    public class FindPeriodsQuery : IQuery<Period[]>
    {
        public string SearchText { get; set; }
        public bool IncludeInactiveUsers { get; set; }
    }
}
