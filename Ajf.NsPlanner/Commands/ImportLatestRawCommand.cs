using System;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;
using Microsoft.Win32;

namespace Ajf.NsPlanner.UI.Commands
{
    public class ImportLatestRawCommand : BaseCommand, IImportLatestRawCommand
    {
        private readonly IDispatcher _dispatcher;
        private readonly IRawRequestRepository _rawRequestRepository;

        public ImportLatestRawCommand(IRawRequestRepository rawRequestRepository, IDispatcher dispatcher)
        {
            _rawRequestRepository = rawRequestRepository;
            _dispatcher = dispatcher;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            try
            {
                var openFileDialog = new OpenFileDialog {Multiselect = false};
                var showDialog = openFileDialog.ShowDialog();

                if (!showDialog.HasValue || !showDialog.Value)
                    return;

                var fileName = openFileDialog.FileName;
                var requestDtos = _rawRequestRepository.List(fileName).ToArray();

                _dispatcher.Dispatch(new ImportRequestsCommand(requestDtos));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}