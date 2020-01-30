using System;
using System.Linq;
using Serilog;
using WixSharp;
using File = System.IO.File;

namespace ConsoleApp1
{
    public class MsiBuilder : IMsiBuilder
    {
        public void BuildMsi()
        {
            try
            {
                Log.Logger.Debug(@"Building MSI...");

                IMsiBuilderSettings msiBuilderSettings = new MsiBuilderSettings();

                var pathChoices = msiBuilderSettings.PathChoices;
                var uiExe = msiBuilderSettings.UiExe;

                Log.Logger.Debug(@"Creating installer for: " + uiExe);

                var path = pathChoices.FirstOrDefault(x => File.Exists(x + @"\" + uiExe));
                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentException("The uiExe was not found: "+uiExe);
                }

                Log.Logger.Debug(@"Chosen path: " + path);

                var guidString = GetGuidString();

                var envStringToShow = GetEnvStringToShow(msiBuilderSettings);
                var releaseNumber = msiBuilderSettings.ReleaseNumber;

                Log.Logger.Debug(@"Release number is: " + releaseNumber);

                var companyName = msiBuilderSettings.CompanyName;
                var productWithEnv = msiBuilderSettings.ProductName + $"{envStringToShow}";

                Log.Logger.Debug(@"Product with env is: " + productWithEnv);

                var x64SqLite = new Feature("x64SqLite");
                var x86SqLite = new Feature("x86SqLite");

                //var exeFileShortcut1 = new ExeFileShortcut(productWithEnv,
                //    $@"%ProgramFiles%\\{companyName}\\{productWithEnv}\\JCI.ITC.SABPrice.UI.exe",
                //    "");
                var exeFileShortcut1 = new ExeFileShortcut(productWithEnv,
                    $@"[INSTALLDIR]\\" + msiBuilderSettings.UiExe,
                    "");
                var exeFileShortcut2 = new ExeFileShortcut($"Uninstall {productWithEnv}", "[System64Folder]msiexec.exe",
                    "/x [ProductCode]");
                var menuDir = new Dir(
                    $"%ProgramMenu%\\{companyName}\\{productWithEnv}",
                    exeFileShortcut1,
                    exeFileShortcut2);

                const string appIconName = "app_icon.ico";
                if (!File.Exists(appIconName))
                {
                    throw new ArgumentException("No app icon file found named : " + appIconName);
                }


                var msiPrefix = msiBuilderSettings.MsiPrefix;
                var project = new Project(
                    $"{productWithEnv} {releaseNumber}",
                    new Dir(
                        $@"%ProgramFiles%\{companyName}\{productWithEnv}",
                        new Files(path + @"\*.*",
                            f => !f.EndsWith(".pdb") && !f.EndsWith(".msi")
                        )
                        //,new Files(x64SqLite, path + @"\x64\SQLite.Interop.dll")
                        //,new Files(x86SqLite, path + @"\x86\SQLite.Interop.dll")
                    ),
                    menuDir
                )
                {
                    GUID = new Guid(guidString),
                    OutFileName = $@".\{msiPrefix}{envStringToShow}.{releaseNumber}",
                    MajorUpgradeStrategy = MajorUpgradeStrategy.Default,
                    Version = new Version(releaseNumber),
                    ControlPanelInfo = {ProductIcon = appIconName}
                };

                var exe = project
                    .ResolveWildCards()
                    .FindFile(f => f.Name.EndsWith(uiExe))
                    .First();

                exe.Shortcuts = new[]
                {
                    new FileShortcut(productWithEnv, "%Desktop%")
                };

                project.Version = new Version(releaseNumber);

                project.ControlPanelInfo.Comments = productWithEnv;
                project.ControlPanelInfo.Readme = "https://jci.com/";
                project.ControlPanelInfo.HelpLink = "https://jci.com/";
                project.ControlPanelInfo.HelpTelephone = "(+45) 6170 8335";
                project.ControlPanelInfo.UrlInfoAbout = "https://jci.com/";
                project.ControlPanelInfo.UrlUpdateInfo = "https://jci.com/";
                project.ControlPanelInfo.ProductIcon = appIconName;
                project.ControlPanelInfo.Contact = "Lane.Hjelme@jci.com";
                project.ControlPanelInfo.Manufacturer = "Sabroe Factory by Johnson Controls";
                project.ControlPanelInfo.InstallLocation = "[INSTALLDIR]";
                project.ControlPanelInfo.NoModify = true;
                //project.ControlPanelInfo.NoRepair = true,
                //project.ControlPanelInfo.NoRemove = true,
                //project.ControlPanelInfo.SystemComponent = true, //if set will not be shown in Control Panel


                project.BannerImage = "TopBanner.bmp";
                project.BackgroundImage = "MainPage.bmp";

                Log.Logger.Debug(@"BuildMSI ");
                Compiler.BuildMsi(project);

                Log.Logger.Debug(@"Succesfully created ");
                Log.Logger.Debug(project.Name);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "During Setup / MSI creation.");
                Environment.ExitCode = 1;
                throw;
            }
        }

        private static string GetEnvStringToShow(IMsiBuilderSettings msiBuilderSettings)
        {
            return msiBuilderSettings.Environment == "PROD"
                ? ""
                : "." + msiBuilderSettings.Environment;
        }

        private static string GetGuidString()
        {
            var msiBuilderSettings = new MsiBuilderSettings();
            var guidStrings = msiBuilderSettings.GuidBasis;


            switch (msiBuilderSettings.Environment.ToLower())
            {
                case "dev":
                    return guidStrings.Substring(0, guidStrings.Length - 1) + "1";
                case "ci":
                    return guidStrings.Substring(0, guidStrings.Length - 1) + "2";
                case "qa":
                    return guidStrings.Substring(0, guidStrings.Length - 1) + "3";
                case "prod":
                    return guidStrings.Substring(0, guidStrings.Length - 1) + "4";
                default:
                    throw new ArgumentException(
                        "Unknown Environment in settings: " + msiBuilderSettings.Environment);
            }
        }
    }
}