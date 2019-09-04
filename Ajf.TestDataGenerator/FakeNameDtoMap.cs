using CsvHelper.Configuration;

namespace Ajf.TestDataGenerator
{
    public class FakeNameDtoMap: ClassMap<FakeNameDto>
    {
        public FakeNameDtoMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.EmailAddress).Name("Email Address");
            Map(m => m.Name).Name("FirstName LastName");
        }
    }
}