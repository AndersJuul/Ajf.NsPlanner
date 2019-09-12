using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;

namespace Ajf.NsPlanner.UI.Commands
{
    public class NewPlaceCommand:BaseCommand, INewPlaceCommand
    {
        private readonly IDispatcher _dispatcher;

        public NewPlaceCommand(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _dispatcher.Dispatch(new AddPlaceCommand());
        }
    }
}