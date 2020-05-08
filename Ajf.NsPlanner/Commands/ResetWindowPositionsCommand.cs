using System;
using Ajf.NsPlanner.UI.Commands.Base;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public class ResetWindowPositionsCommand : BaseCommand, IResetWindowPositionsCommand
    {
        
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            WindowManager.ResetWindowPositions();
        }
    }
}