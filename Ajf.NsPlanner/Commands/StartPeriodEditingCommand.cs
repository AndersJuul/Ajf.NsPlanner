using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;
using Ajf.NsPlanner.UI.ViewModels;
using Ajf.NsPlanner.UI.Views;

namespace Ajf.NsPlanner.UI.Commands
{
    public class StartPeriodEditingCommand : BaseCommand, IStartPeriodEditingCommand
    {
        private readonly IRepository _repository;
        private readonly IDispatcher _dispatcher;

        public StartPeriodEditingCommand(IRepository repository, IDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }

        public override bool CanExecute(object parameter)
        {
            var mainWindowViewModel = (parameter as IMainWindowViewModel);

            return mainWindowViewModel?.AssignmentsViewModel?.SelectedAssignment != null;
        }

        public override void Execute(object parameter)
        {
            var mainWindowViewModel = parameter as IMainWindowViewModel;
            if (mainWindowViewModel == null)
                return;

            var selectedPeriodId = mainWindowViewModel.PeriodSelectionViewModel.SelectedPeriod.Id;
            var period = _repository.GetById<Period>(selectedPeriodId);

            var editPeriodViewModel = new PeriodViewModel(period, _dispatcher );

            mainWindowViewModel.RequestedDialog = new RequestedDialog("P", editPeriodViewModel, WindowState2.ShowDialog, true);
        }
    }
}