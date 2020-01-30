
namespace ConsoleApp1
{
    public class MsiBuilderSettings: IMsiBuilderSettings
    {
        public MsiBuilderSettings()
        {
            IdentitySettingsEnricher.Enrich(this);

            UiExe = SettingsEnricher.ValueByKeyString("UiExe");
            ProductName = SettingsEnricher.ValueByKeyString("ProductName");
            PathChoices = SettingsEnricher.ValueByKeyStringArray("PathChoices");
            GuidBasis = SettingsEnricher.ValueByKeyString("GuidBasis");
            CompanyName = SettingsEnricher.ValueByKeyString("CompanyName");
            MsiPrefix = SettingsEnricher.ValueByKeyString("MsiPrefix");
        }

        public string ReleaseNumber { get; set; }
        public string ComponentName { get; set; }
        public string SuiteName { get; set; }
        public string Environment { get; set; }

        public string UiExe { get; set; }
        public string ProductName { get; set; }
        public string[] PathChoices { get; set; }
        public string GuidBasis { get; set; }
        public string CompanyName { get; set; }
        public string MsiPrefix { get; set; }
    }
}