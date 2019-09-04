using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;

namespace Ajf.NsPlanner.UI.Commands
{
    public class DeletePeriodCommand : BaseCommand, IDeletePeriodCommand
    {
        private readonly IDispatcher _dispatcher;

        public DeletePeriodCommand(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public override bool CanExecute(object parameter)
        {
            var vm = (parameter as IMainWindowViewModel)?.PeriodSelectionViewModel;

            return vm != null && vm.IsPeriodSelected;
        }

        public override void Execute(object parameter)
        {
            var vm = (parameter as IMainWindowViewModel)?.PeriodSelectionViewModel;
            if (vm == null)
                throw new ArgumentNullException(nameof(parameter));

            try
            {
                _dispatcher.Dispatch(new Application.Commands.DeletePeriodCommand(vm.SelectedPeriod.Id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}