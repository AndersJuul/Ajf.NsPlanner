using System;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Domain.Queries
{
    public class ListAvailableDatesQuery : IQuery<AvailableDate[]>
    {
        public Guid PeriodId { get; }

        public ListAvailableDatesQuery(Guid periodId)
        {
            PeriodId = periodId;
        }
    }
}