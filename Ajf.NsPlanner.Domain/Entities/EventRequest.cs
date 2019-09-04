using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class EventRequest : BaseEntity
    {
        public EventRequest(string timeStamp, string contactName) : this()
        {
            TimeStamp = timeStamp;
            ContactName = contactName;
        }

        private EventRequest()
        {
        }

        public string TimeStamp { get; protected set; }

        public string ContactName { get; protected set; }

        public string ContactPhone { get; protected set; }
        public string ContactEmail { get; protected set; }
        public string SchoolInstituteName { get; protected set; }
        public string ParticipantsGroup { get; protected set; }
        public string ParticipantsAge { get; protected set; }
        public string ParticipantsNumber { get; protected set; }
        public string DesiredEvent { get; protected set; }
        public string DesiredMeetingPoint { get; protected set; }
        public string DesiredWhen { get; protected set; }
        public string DesiredDate { get; protected set; }
        public string Comments { get; protected set; }
        public string InstitutionOrSchool { get; protected set; }
        public string ContactSummary => string.Format("{0} ({1})", ContactName, ContactEmail);
        public string DesireSummary => string.Format("{0}//{1}//{2}//{3}", DesiredEvent, DesiredDate, DesiredMeetingPoint, DesiredWhen);

        public static EventRequest Create(string timeStamp, string contactName)
        {
            return new EventRequest(timeStamp, contactName);
        }

        public void UpdateFrom(EventRequest source)
        {
            TimeStamp = source.TimeStamp;
            ContactName = source.ContactName;
            ContactPhone = source.ContactPhone;
            ContactEmail = source.ContactEmail;
            SchoolInstituteName = source.SchoolInstituteName;
            ParticipantsGroup = source.ParticipantsGroup;
            ParticipantsAge = source.ParticipantsAge;
            ParticipantsNumber = source.ParticipantsNumber;
            DesiredEvent = source.DesiredEvent;
            DesiredMeetingPoint = source.DesiredMeetingPoint;
            DesiredWhen = source.DesiredWhen;
            DesiredDate = source.DesiredDate;
            Comments = source.Comments;
            InstitutionOrSchool = source.InstitutionOrSchool;
        }
    }
}