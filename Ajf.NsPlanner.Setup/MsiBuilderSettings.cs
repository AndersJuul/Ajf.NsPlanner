
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace ConsoleApp1
{
    public class MsiBuilderSettings: IMsiBuilderSettings
    {
        public MsiBuilderSettings()
        {
            IdentitySettingsEnricher.Enrich(this);
            LogginSettingsEnricher.Enrich(this);

            UiExe = SettingsEnricher.ValueByKeyString("UiExe");
            ProductName = SettingsEnricher.ValueByKeyString("ProductName");
            PathChoices = SettingsEnricher.ValueByKeyStringArray("PathChoices");
            GuidBasis = SettingsEnricher.ValueByKeyString("GuidBasis");
            CompanyName = SettingsEnricher.ValueByKeyString("CompanyName");
            MsiPrefix = SettingsEnricher.ValueByKeyString("MsiPrefix");

            FileName= SettingsEnricher.ValueByKeyString("FileName");
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
        public string EsLoggingUrl { get; set; }
        public LogEventLevel LoggingLevel { get; set; }
        public string FileName { get; set; }
        public string LogFileDirectory { get; set; }
        public ElasticsearchSinkOptions ElasticsearchSinkOptions { get; set; }
    }
}