using System;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class AssignmentViewModel: ViewModel
    {
        private readonly Assignment _assignment;

        public AssignmentViewModel(Assignment assignment)
        {
            _assignment = assignment;
        }

        public Guid Id => _assignment.Id;
        public string Comment => _assignment.Comment;
        public string TimeStamp => _assignment.EventRequest.TimeStamp;
        public string Person => _assignment.EventRequest.ContactSummary;
        public string SchoolInstituteName => _assignment.EventRequest.SchoolInstituteName;
        public string Desire => _assignment.EventRequest.DesireSummary;
        public string EventComment => _assignment.EventRequest.Comments;
        public string Marker => _assignment.Marker;
        public string SpecificationStatus => Translate(_assignment.SpecificationStatus);

        private string Translate(SpecificationStatus specificationStatus)
        {
            switch (specificationStatus)
            {
                case Domain.Entities.SpecificationStatus.FullySpecified:
                    return "Fuldt";
                case Domain.Entities.SpecificationStatus.PartlySpecified:
                    return "Delvis";
                case Domain.Entities.SpecificationStatus.Unspecified:
                    return "Uspec";

                default: return "FEJL";
            }
        }

        public AssignmentViewModel Clone()
        {
            var assignment = _assignment.Clone();
            return new AssignmentViewModel(assignment);
        }

        public void ModelUpdate(Assignment assignment)
        {
            _assignment.UpdateFrom(assignment);

            OnPropertyChanged(nameof(SpecificationStatus));
            OnPropertyChanged(nameof(Marker));
        }

        public bool RefersEventRequest(EventRequest eventRequest)
        {
            return _assignment.EventRequest.Id == eventRequest.Id;
        }

        public void NotifyAll()
        {
            OnPropertyChanged(nameof(Comment));
            OnPropertyChanged(nameof(EventComment));
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Person));
            OnPropertyChanged(nameof(SchoolInstituteName));
            OnPropertyChanged(nameof(SpecificationStatus));
            OnPropertyChanged(nameof(TimeStamp));
            OnPropertyChanged(nameof(Marker));
        }
    }
}