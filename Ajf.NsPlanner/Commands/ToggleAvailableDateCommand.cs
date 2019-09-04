using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;

namespace Ajf.NsPlanner.UI.Commands
{
    public class ToggleAvailableDateCommand :BaseCommand, IToggleAvailableDateCommand
    {
        private readonly IDispatcher _dispatcher;

        public ToggleAvailableDateCommand(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter is IAvailableDateViewModel model)
            {
                return true;
            }

            return false;
        }

        public override void Execute(object parameter)
        {
            var model = (parameter as IAvailableDateViewModel);
            _dispatcher.Dispatch(new ToggleAvailableDateXCommand(model.Id));
        }
    }
}