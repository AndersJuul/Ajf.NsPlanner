using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Domain.Queries
{
    public class EmailAddressesQuery : IQuery<SimpleStatTable>
    {
        public Assignment[] Assignments { get; }
        public EmailAddressesQuery(Assignment[] assignments)
        {
            Assignments = assignments;
        }
    }
}