using CsvHelper.Configuration;

namespace Ajf.TestDataGenerator
{
    internal class FakePartialRequestDtoMap : ClassMap<FakePartialRequestDto>
    {
        public FakePartialRequestDtoMap()
        {
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