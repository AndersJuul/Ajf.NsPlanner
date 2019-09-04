using System.Collections.ObjectModel;
using Ajf.NsPlanner.Application.CommandHandlers;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IAssignmentsViewModel: IHandle<AssignmentUpdatedEvent>, IHandle<EventRequestUpdatedEvent>
    {
        ObservableCollection<AssignmentViewModel> Items { get; }
        AssignmentViewModel SelectedAssignment { get; set; }
        string Target { get; set; }
        void ReloadAssignmentsFromDb();
    }
}