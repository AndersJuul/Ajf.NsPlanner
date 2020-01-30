namespace ConsoleApp1
{
    public interface IIdentitySettings
    {
        string ReleaseNumber { get; set; }
        string Environment { get; set; }
    }
}