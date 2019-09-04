using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Domain.Queries
{
    public class AcceptedRejectedQuery : IQuery<SimpleStatTable>
    {
        public Assignment[] Assignments { get; }

        public AcceptedRejectedQuery(Assignment[] assignments)
        {
            Assignments = assignments;
        }
    }
}