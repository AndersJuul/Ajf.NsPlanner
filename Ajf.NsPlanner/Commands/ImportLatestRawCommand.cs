using System;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Commands.Base;

namespace Ajf.NsPlanner.UI.Commands
{
    public class ImportLatestRawCommand :BaseCommand, IImportLatestRawCommand
    {
        private readonly IRawRequestRepository _rawRequestRepository;
        private readonly IDispatcher _dispatcher;

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
                var requestDtos = _rawRequestRepository.List().ToArray();
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