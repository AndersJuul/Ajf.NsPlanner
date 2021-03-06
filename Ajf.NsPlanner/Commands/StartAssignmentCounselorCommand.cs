﻿using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;
using Ajf.NsPlanner.UI.ViewModels;
using Ajf.NsPlanner.UI.Views;

namespace Ajf.NsPlanner.UI.Commands
{
    public class StartAssignmentCounselorCommand : StartAssignmentBaseCommand, IStartAssignmentCounselorCommand
    {
        private readonly IRepository _repository;
        private readonly IDispatcher _dispatcher;

        public StartAssignmentCounselorCommand(IRepository repository, IDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }

        public override void Execute(object parameter)
        {
            if (!(parameter is IMainWindowViewModel mainWindowViewModel))
                return;

            var selectedAssignmentId = mainWindowViewModel.AssignmentsViewModel.SelectedAssignment.Id;
            var assignment = _repository.GetById<Assignment>(selectedAssignmentId);

            mainWindowViewModel.EditAssignmentViewModel.SelectedCounselor =
                mainWindowViewModel.EditAssignmentViewModel.Counselors.SingleOrDefault(x => x.Id == assignment?.Counselor?.Id);
            mainWindowViewModel.RequestedDialog = new RequestedDialog("C", mainWindowViewModel.EditAssignmentViewModel, WindowState2.ShowDialog, true);
        }
    }
}