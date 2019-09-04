using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class StatsSchoolsViewModel : StatsBaseViewModel<IQuery<SimpleStatTable>, SimpleStatTable>,
        IStatsSchoolsViewModel
    {
        public StatsSchoolsViewModel(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public override string Title => SelectedPeriod == null
            ? "Ingen periode valgt"
            : "Skolestat for " + SelectedPeriod.DateRange;

        protected override IQuery<SimpleStatTable> GetQuery(Assignment[] currentAssignments)
        {
            return new SchoolQuery(currentAssignments);
        }
    }
}