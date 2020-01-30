using System;
using System.Configuration;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

//using Serilog.Sinks.Elasticsearch;

namespace ConsoleApp1
{
    public class SettingsFromConfigFile
    {
        public SettingsFromConfigFile()
        {
            Environment = ConfigurationManager.AppSettings["Environment"];
            SuiteName = ConfigurationManager.AppSettings["SuiteName"];
            ComponentName = ConfigurationManager.AppSettings["ComponentName"];
            LogFileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            EsLoggingUrl = ConfigurationManager.AppSettings["EsLoggingUrl"];
            ReleaseNumber = ConfigurationManager.AppSettings["ReleaseNumber"];

            var loggingLevel = ConfigurationManager.AppSettings["LoggingLevel"];
            if (string.IsNullOrEmpty(loggingLevel))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(loggingLevel));
            LoggingLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), loggingLevel);

            if (string.IsNullOrEmpty(Environment))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(Environment));
            if (string.IsNullOrEmpty(SuiteName))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(SuiteName));
            if (string.IsNullOrEmpty(ComponentName))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(ComponentName));
            if (string.IsNullOrEmpty(LogFileDirectory))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(LogFileDirectory));
            if (string.IsNullOrEmpty(EsLoggingUrl))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(EsLoggingUrl));
            if (string.IsNullOrEmpty(ReleaseNumber))
                throw new ArgumentException("AppSetting can't be null/empty", nameof(ReleaseNumber));

            FileName = $"{LogFileDirectory}{SuiteName}.{ComponentName}.log";

            EsLoggingUri = new Uri(EsLoggingUrl);
            ElasticsearchSinkOptions = new ElasticsearchSinkOptions(EsLoggingUri);
            EasyNetQConfig = ConfigurationManager.AppSettings["EasyNetQConfig"];
        }

        public string LogFileDirectory { get; set; }

        public string ReleaseNumber { get; set; }
        public string ComponentName { get; set; }
        public string SuiteName { get; set; }
        public string FileName { get; set; }
        public string EsLoggingUrl { get; set; }
        public Uri EsLoggingUri { get; set; }
        public ElasticsearchSinkOptions ElasticsearchSinkOptions { get; set; }
        public string Environment { get; set; }
        public string EasyNetQConfig { get; set; }
        public LogEventLevel LoggingLevel { get; set; }
    }
}