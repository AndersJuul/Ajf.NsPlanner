using System;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IAssignmentViewModel:IViewModel
    {
        Guid Id { get; }
        string Comment { get; }
        string TimeStamp { get; }
        string Person { get; }
        string SchoolInstituteName { get; }
        string Desire { get; }
        string EventComment { get; }
        string Marker { get; }
        string SpecificationStatus { get; }
        Assignment Assignment { get; }
        void ModelUpdate(Assignment assignment);
        bool RefersEventRequest(EventRequest eventRequest);
        void NotifyAll();
    }
}