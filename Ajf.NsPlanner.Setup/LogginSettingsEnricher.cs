using System;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace ConsoleApp1
{
    public class LogginSettingsEnricher
    {
        public static void Enrich(ILoggingSettings loggingSettings)
        {
            loggingSettings.EsLoggingUrl = SettingsEnricher.ValueByKeyString("EsLoggingUrl");
            loggingSettings.LogFileDirectory = SettingsEnricher.ValueByKeyString("LogFileDirectory");
            loggingSettings.FileName = SettingsEnricher.ValueByKeyString("FileName");
            if (!Enum.TryParse(SettingsEnricher.ValueByKeyString("LoggingLevel"), out LogEventLevel logEventLevel))
                throw new InvalidOperationException("Could not read value of LoggingLevel as LogEventLevel");
            loggingSettings.LoggingLevel = logEventLevel;
            loggingSettings.ElasticsearchSinkOptions = new ElasticsearchSinkOptions
                {MinimumLogEventLevel = logEventLevel};
        }
    }
}