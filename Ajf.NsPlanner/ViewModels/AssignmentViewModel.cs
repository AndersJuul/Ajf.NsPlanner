using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class AssignmentViewModel: ViewModel, IAssignmentViewModel
    {
        private readonly IDispatcher _dispatcher;
        public Assignment Assignment { get; }

        public AssignmentViewModel(Assignment assignment, IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            Assignment = assignment;
        }

        public Guid Id => Assignment.Id;
        public string Comment
        {
            get => Assignment.Comment;
            set
            {
                Assignment.Comment = value; 
                CommitChanges();
                OnPropertyChanged();
            }
        }

        public string TimeStamp => Assignment.EventRequest.TimeStamp;
        public string Person => Assignment.EventRequest.ContactSummary;
        public string SchoolInstituteName => Assignment.EventRequest.SchoolInstituteName;
        public string Desire => Assignment.EventRequest.DesireSummary;
        public string EventComment => Assignment.EventRequest.Comments;
        public string Marker => Assignment.Marker;
        public string SpecificationStatus => Translate(Assignment.SpecificationStatus);


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
        public void CommitChanges()
        {
            try
            {
                _dispatcher.Dispatch(new UpdateAssignmentCommand(Assignment));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ModelUpdate(Assignment assignment)
        {
            Assignment.UpdateFrom(assignment);

            OnPropertyChanged(nameof(SpecificationStatus));
            OnPropertyChanged(nameof(Marker));
        }

        public bool RefersEventRequest(EventRequest eventRequest)
        {
            return Assignment.EventRequest.Id == eventRequest.Id;
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