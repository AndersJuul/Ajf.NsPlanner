﻿using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;

namespace Ajf.NsPlanner.UI.Commands
{
    public class NewPeriodCommand : BaseCommand, INewPeriodCommand
    {
        private readonly IDispatcher _dispatcher;

        public NewPeriodCommand(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var vm = parameter as IMainWindowViewModel;
            if (vm == null)
                throw new ArgumentNullException(nameof(parameter));

            _dispatcher.Dispatch(new AddPeriodCommand());
        }
    }
}