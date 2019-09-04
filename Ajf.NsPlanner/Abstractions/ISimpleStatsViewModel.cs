using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.Queries;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface ISimpleStatsViewModel:IViewModel, IShowAndHideWindows, IRememberWindowPosition, IHandle<AssignmentUpdatedEvent>
    {
        IPeriodViewModel SelectedPeriod { get; set; }
        SimpleStatTable StatTable { get; set; }
        string Translate(string columnName);
    }
}