using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Domain.Queries
{
    public class SchoolQuery : IQuery<SimpleStatTable>
    {
        public Assignment[] Assignments { get; }

        public SchoolQuery(Assignment[] assignments)
        {
            Assignments = assignments;
        }
    }
}