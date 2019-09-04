using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class StatsAcceptedRejectedViewModel : StatsBaseViewModel<IQuery<SimpleStatTable>, SimpleStatTable>,
        IStatsAcceptedRejectedViewModel
    {
        public StatsAcceptedRejectedViewModel(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public override string Title => SelectedPeriod == null
            ? "Ingen periode valgt"
            : "Tildelingsstat for " + SelectedPeriod.DateRange;

        protected override IQuery<SimpleStatTable> GetQuery(Assignment[] currentAssignments)
        {
            return new AcceptedRejectedQuery(currentAssignments);
        }
    }
}