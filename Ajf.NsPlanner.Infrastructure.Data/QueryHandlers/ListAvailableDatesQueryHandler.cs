using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.Infrastructure.Data.Data;

namespace Ajf.NsPlanner.Infrastructure.Data.QueryHandlers
{
    public class ListAvailableDatesQueryHandler : IQueryHandler<ListAvailableDatesQuery, AvailableDate[]>
    {
        private readonly AppDbContext _appDbContext;

        public ListAvailableDatesQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public AvailableDate[] Handle(ListAvailableDatesQuery query)
        {
            return (
                    from availableDate in _appDbContext.AvailableDates
                    where availableDate.PeriodId==query.PeriodId
                    select availableDate)
                .ToArray();
        }
    }
}