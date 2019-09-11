using System;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class Assignment : AggregateRoot
    {
        private Counselor _counselor;
        private SpecificationStatus _specificationStatus;

        private Assignment()
        {
        }

        public EventRequest EventRequest { get; set; }
        public SchoolEvent SchoolEvent { get; set; }

        public Counselor Counselor
        {
            get => _counselor;
            set
            {
                _counselor = value;
                SpecificationStatus =Recalculate();
            }
        }

        public string Marker { get; set; }

        public SpecificationStatus SpecificationStatus
        {
            get
            {
                if(_specificationStatus==SpecificationStatus.None)
                    SpecificationStatus = Recalculate();

                return _specificationStatus;
            }
            protected set => _specificationStatus = value;
        }

        public Place Place { get; set; }
        public DateTime DateTimeOfStart { get; set; }
        public string Comment { get; set; }
        public bool IsAccepted => Counselor != null;
        public bool IsRejected=> Counselor == null;

        private SpecificationStatus Recalculate()
        {
            var validationStatus = SpecificationStatus.PartlySpecified;

            if (Counselor == null && Place == null && SchoolEvent == null)
                validationStatus = SpecificationStatus.Unspecified;

            if (Counselor != null && Place != null && SchoolEvent != null)
                validationStatus = SpecificationStatus.FullySpecified;

            return validationStatus;
        }

        public static Assignment Create(EventRequest newEventRequest)
        {
            var assignment = new Assignment
            {
                EventRequest = newEventRequest
            };
            assignment.Recalculate();
            assignment.Events.Add(new AssignmentCreatedEvent(assignment));

            return assignment;
        }

        public void UpdateFrom(Assignment assignment)
        {
            Counselor = assignment.Counselor;
            Marker = assignment.Marker;
            Recalculate();
        }
    }
}