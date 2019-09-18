using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;
using Ajf.NsPlanner.UI.ViewModels;
using Ajf.NsPlanner.UI.Views;

namespace Ajf.NsPlanner.UI.Commands
{
    public class StartAssignmentPlaceCommand : StartAssignmentBaseCommand, IStartAssignmentPlaceCommand
    {
        private readonly IRepository _repository;
        private readonly IDispatcher _dispatcher;

        public StartAssignmentPlaceCommand(IRepository repository, IDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }

        public override void Execute(object parameter)
        {
            var mainWindowViewModel = parameter as IMainWindowViewModel;
            if (mainWindowViewModel == null)
                return;

            var selectedAssignmentId = mainWindowViewModel.AssignmentsViewModel.SelectedAssignment.Id;
            var assignment = _repository.GetById<Assignment>(selectedAssignmentId);

            mainWindowViewModel.EditAssignmentViewModel.SelectedPlace =
                mainWindowViewModel.EditAssignmentViewModel.Places.SingleOrDefault(x => x.Id == assignment?.Place?.Id);
            mainWindowViewModel.RequestedDialog = new RequestedDialog("PL", mainWindowViewModel.EditAssignmentViewModel, WindowState2.ShowDialog, true);
        }
    }
}