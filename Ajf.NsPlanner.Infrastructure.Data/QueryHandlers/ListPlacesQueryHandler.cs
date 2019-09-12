using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.Infrastructure.Data.Data;

namespace Ajf.NsPlanner.Infrastructure.Data.QueryHandlers
{
    public class ListPlacesQueryHandler: IQueryHandler<ListPlacesQuery, Place[]>
    {
        private readonly AppDbContext _appDbContext;

        public ListPlacesQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Place[] Handle(ListPlacesQuery query)
        {
            return (
                    from counselor in _appDbContext.Places
                    select counselor
                    )
                .ToArray();
        }
    }
}