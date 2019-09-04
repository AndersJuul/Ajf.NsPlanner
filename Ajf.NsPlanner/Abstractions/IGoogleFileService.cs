namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IGoogleFileService
    {
        void DownloadFile(string fileId, string destinationPath);
    }
}