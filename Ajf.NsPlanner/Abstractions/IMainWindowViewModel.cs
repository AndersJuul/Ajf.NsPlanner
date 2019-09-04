using Ajf.NsPlanner.Application.CommandHandlers;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.UI.ViewModels;
using Ajf.NsPlanner.UI.Views;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IMainWindowViewModel:IViewModel, IHandle<AssignmentCreatedEvent>, IHandle<EventRequestUpdatedEvent>
    {
        IPeriodSelectionViewModel PeriodSelectionViewModel { get; set; }
        IAssignmentsViewModel AssignmentsViewModel { get; }
        RequestedDialog RequestedDialog { get; set; }
        void OnLoaded();
    }
}