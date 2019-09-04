using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Ajf.NsPlanner.Infrastructure.Data.QueryHandlers
{
    public class FindAssignmentsByPeriodQueryHandler
        : IQueryHandler<FindAssignmentsByTargetQuery, Assignment[]>
    {
        private readonly AppDbContext _appDbContext;

        public FindAssignmentsByPeriodQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Assignment[] Handle(FindAssignmentsByTargetQuery query)
        {
            var assignments = (
                from assignment in _appDbContext
                    .Assignments
                    .Include(x=>x.EventRequest)
                    .Include(x=>x.Counselor)
                where assignment.EventRequest.DesiredWhen.Equals(query.Target)
                select assignment);

            foreach (var f in query.Funcs)
            {
                assignments = f(assignments);
            }

            return assignments.ToArray();
        }
    }
}