using System;
using System.Collections.Generic;
using System.Text;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;

namespace Ajf.NsPlanner.UI.Commands
{
    public class SetMarkerCommand:BaseCommand, ISetMarkerCommand
    {
        private readonly IAssignmentsViewModel _assignmentsViewModel;
        private readonly IDispatcher _dispatcher;

        public SetMarkerCommand(IAssignmentsViewModel assignmentsViewModel,IDispatcher dispatcher)
        {
            _assignmentsViewModel = assignmentsViewModel;
            _dispatcher = dispatcher;
        }
        public override bool CanExecute(object parameter)
        {
            return _assignmentsViewModel.SelectedAssignment != null;
        }

        public override void Execute(object parameter)
        {
            _dispatcher.Dispatch(new SetMarkerOnAssignmentCommand(parameter as string, _assignmentsViewModel.SelectedAssignment.Id));
        }
    }
}
