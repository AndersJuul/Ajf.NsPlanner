using Serilog;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var msiBuilderSettings = new MsiBuilderSettings();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(msiBuilderSettings.LoggingLevel)
                .Enrich.WithMachineName()
                .Enrich.WithProperty("ReleaseNumber", msiBuilderSettings.ReleaseNumber)
                .Enrich.WithProperty("Environment", msiBuilderSettings.Environment)
                .Enrich.WithProperty("SuiteName", msiBuilderSettings.SuiteName)
                .Enrich.WithProperty("ComponentName", msiBuilderSettings.ComponentName)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(msiBuilderSettings.FileName)
                .WriteTo.Elasticsearch(msiBuilderSettings.ElasticsearchSinkOptions)
                .WriteTo.Console()
                .CreateLogger();

            new MsiBuilder().BuildMsi(msiBuilderSettings);
        }
    }
}
