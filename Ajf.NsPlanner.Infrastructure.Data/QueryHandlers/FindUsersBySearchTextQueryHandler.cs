using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.Infrastructure.Data.Data;

namespace Ajf.NsPlanner.Infrastructure.Data.QueryHandlers
{
    public class FindUsersBySearchTextQueryHandler
        : IQueryHandler<FindPeriodsQuery, Period[]>
    {
        private readonly AppDbContext _appDbContext;

        public FindUsersBySearchTextQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Period[] Handle(FindPeriodsQuery query)
        {
            return (
                    from period in _appDbContext.Periods
                    orderby period.DateRange.Start descending 
                    select period
                    )
                .ToArray();
        }
    }
}