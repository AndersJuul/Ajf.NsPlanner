using System.Collections.ObjectModel;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Events;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IAssignmentsViewModel :IViewModel, IHandle<AssignmentUpdatedEvent>, IHandle<EventRequestUpdatedEvent>
    {
        ObservableCollection<IAssignmentViewModel> Items { get; }
        IAssignmentViewModel SelectedAssignment { get; set; }
        string Target { get; set; }
        void ReloadAssignmentsFromDb();
    }
}