using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.Commands.Base
{
    public abstract class StartAssignmentBaseCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var mainWindowViewModel = (parameter as IMainWindowViewModel);

            return mainWindowViewModel?.AssignmentsViewModel?.SelectedAssignment != null;
        }
    }
}