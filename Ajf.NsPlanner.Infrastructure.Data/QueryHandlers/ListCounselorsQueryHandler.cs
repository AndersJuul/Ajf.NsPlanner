using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.Infrastructure.Data.Data;

namespace Ajf.NsPlanner.Infrastructure.Data.QueryHandlers
{
    public class ListCounselorsQueryHandler
        : IQueryHandler<ListCounselorsQuery, Counselor[]>
    {
        private readonly AppDbContext _appDbContext;

        public ListCounselorsQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Counselor[] Handle(ListCounselorsQuery query)
        {
            return (
                    from counselor in _appDbContext.Counselors
                    select counselor
                    )
                .ToArray();
        }
    }
}