using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace ConsoleApp1
{
    public interface ILoggingSettings
    {
        string EsLoggingUrl { get; set; }
        LogEventLevel LoggingLevel { get; set; }
        string FileName { get; set; }
        string LogFileDirectory { get; set; }
        ElasticsearchSinkOptions ElasticsearchSinkOptions { get; set; }
    }
}