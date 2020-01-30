using Serilog;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new SettingsFromConfigFile();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(settings.LoggingLevel)
                //.Enrich.WithMachineName()
                .Enrich.WithProperty("ReleaseNumber", settings.ReleaseNumber)
                .Enrich.WithProperty("Environment", settings.Environment)
                .Enrich.WithProperty("SuiteName", settings.SuiteName)
                .Enrich.WithProperty("ComponentName", settings.ComponentName)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(settings.FileName)
                .WriteTo.Elasticsearch(settings.ElasticsearchSinkOptions)
                .CreateLogger();

            new MsiBuilder().BuildMsi();
        }
    }
}
