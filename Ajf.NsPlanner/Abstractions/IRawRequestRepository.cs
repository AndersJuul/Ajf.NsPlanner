using System.Collections.Generic;
using Ajf.NsPlanner.Application.Dtos;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IRawRequestRepository
    {
        IEnumerable<RequestDto> List();
    }
}