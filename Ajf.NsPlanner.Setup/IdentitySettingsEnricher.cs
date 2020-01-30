namespace ConsoleApp1
{
    public class IdentitySettingsEnricher
    {
        public static void Enrich(IIdentitySettings identitySettings)
        {
            identitySettings.ReleaseNumber = SettingsEnricher.ValueByKeyString("ReleaseNumber");
            identitySettings.Environment = SettingsEnricher.ValueByKeyString("Environment");

            //identitySettings.UiExe = SettingsEnricher.ValueByKeyString("UiExe");
            //ProductName = SettingsEnricher.ValueByKeyString("ProductName");
            //PathChoices = SettingsEnricher.ValueByKeyStringArray("PathChoices");
            //GuidBasis = SettingsEnricher.ValueByKeyString("GuidBasis");
            //CompanyName = SettingsEnricher.ValueByKeyString("CompanyName");
            //MsiPrefix = SettingsEnricher.ValueByKeyString("MsiPrefix");
        }
    }
}