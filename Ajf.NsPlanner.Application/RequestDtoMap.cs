using Ajf.NsPlanner.Application.Dtos;
using CsvHelper.Configuration;

namespace Ajf.NsPlanner.UI.Services
{
    public sealed class RequestDtoMap : ClassMap<RequestDto>
    {
        public RequestDtoMap()
        {
            Map(m => m.TimeStamp).Name("Tidsstempel");
            Map(m => m.ContactName).Name("Kontaktperson, navn");
            Map(m => m.ContactPhone).Name("Kontaktperson, telefon");
            Map(m => m.ContactEmail).Name("Kontaktperson, email - af hensyn til sikkerheden SKAL du benytte din arbejdsmail: xx@slagelse.dk");
            Map(m => m.SchoolInstituteName).Name("Skole/Institution, navn");
            Map(m => m.ParticipantsGroup).Name("Deltagergruppe");
            Map(m => m.ParticipantsAge).Name("Deltagere, aldersinterval");
            Map(m => m.ParticipantsNumber).Name("Deltagere, antal");
            Map(m => m.DesiredEvent).Name("Ønsket arrangement");
            Map(m => m.DesiredMeetingPoint).Name("Ønsket mødested");
            Map(m => m.DesiredWhen).Name("Hvornår ønskes arrangement?");
            Map(m => m.DesiredDate).Name("Ønsket dato for afholdelse");
            Map(m => m.Comments).Name("Bemærkninger");
            Map(m => m.InstitutionOrSchool).Name("Institution eller skole");
        }
    }
}