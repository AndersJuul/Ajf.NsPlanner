using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Dtos;

namespace Ajf.NsPlanner.Application.Commands
{
    public class ImportRequestsCommand:ICommand
    {
        public ImportRequestsCommand(RequestDto[] requestDtos)
        {
            RequestDtos = requestDtos;
        }

        public RequestDto[] RequestDtos { get; }
    }
}