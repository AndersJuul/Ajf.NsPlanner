using System.Configuration;

namespace ConsoleApp1
{
    public class SettingsEnricher
    {
        public static string ValueByKeyString(string s)
        {
            return ConfigurationManager.AppSettings[s];
        }

        public static string[] ValueByKeyStringArray(string s)
        {
            return ConfigurationManager.AppSettings[s].Split('|');
        }
    }
}