using System;
using System.IO;

namespace Ajf.NsPlanner.UI.Services
{
    public static class Globals
    {
        public static string NsFolderPath()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var nsFolderPath = Path.Combine(folderPath, "NsPlanner");
            return nsFolderPath;
        }
    }
}