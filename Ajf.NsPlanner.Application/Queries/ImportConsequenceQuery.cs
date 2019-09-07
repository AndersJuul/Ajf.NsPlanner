using Ajf.NsPlanner.Application.Dtos;
using Ajf.NsPlanner.Domain.Abstractions;

namespace Ajf.NsPlanner.Application.Queries
{
    public class ImportConsequenceQuery : IQuery<ImportConsequenceDto>
    {
        public ImportConsequenceQuery(RequestDto[] requestDtos)
        {
            RequestDtos = requestDtos;
        }

        public RequestDto[] RequestDtos { get; }
    }
}