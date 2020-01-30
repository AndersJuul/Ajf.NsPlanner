
namespace ConsoleApp1
{
    public interface IMsiBuilderSettings:IIdentitySettings
    {
        string UiExe { get; set; }
        string ProductName { get; set; }
        string[] PathChoices { get; set; }
        string GuidBasis { get; set; }
        string CompanyName { get; set; }
        string MsiPrefix { get; set; }
        string ReleaseNumber { get; set; }
        string Environment { get; set; }
    }
}