using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Domain.Queries
{
    public class FindAssignmentsByTargetQuery : IQuery<Assignment[]>
    {
        public FindAssignmentsByTargetQuery(string target,IEnumerable< Func<IQueryable<Assignment>, IQueryable<Assignment>>> funcs)
        {
            Target = target;
            Funcs = funcs;
        }

        public string Target { get; }
        public IEnumerable<Func<IQueryable<Assignment>, IQueryable<Assignment>>> Funcs { get; }
    }
}