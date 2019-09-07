using System;
using Ajf.NsPlanner.Application.Dtos;
using Ajf.NsPlanner.Application.Queries;
using Ajf.NsPlanner.Domain.Abstractions;

namespace Ajf.NsPlanner.Application.QueryHandlers
{
    public class ImportConsequenceQueryHandler : IQueryHandler<ImportConsequenceQuery, ImportConsequenceDto>
    {
        public ImportConsequenceDto Handle(ImportConsequenceQuery query)
        {
            throw new NotImplementedException();
        }
    }
}