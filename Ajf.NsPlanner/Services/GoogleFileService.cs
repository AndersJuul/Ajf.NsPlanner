//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Threading;
//using Ajf.NsPlanner.Application.Models;
//using Ajf.NsPlanner.UI.Abstractions;
//using CsvHelper;
//using CsvHelper.Configuration;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Download;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using Newtonsoft.Json;

//namespace Ajf.NsPlanner.UI.Services
//{
//    public class GoogleFileService : IGoogleFileService
//    {
//        // If modifying these scopes, delete your previously saved credentials
//        // at ~/.credentials/drive-dotnet-quickstart.json
//        private static readonly string[] Scopes = { DriveService.Scope.DriveReadonly };
//        private static readonly string ApplicationName = "Drive API .NET Quickstart1";

//        public void DownloadFile(string fileId, string destinationPath)
//        {
//            var credential = GetUserCredentials();

//            // Create Drive API service.
//            var service = new DriveService(new BaseClientService.Initializer
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName
//            });

//            // Define parameters of request.
//            var listRequest = service.Files.List();
//            listRequest.PageSize = 10;
//            listRequest.Fields = "nextPageToken, files(id, name)";

//            // List files.
//            var files = listRequest.Execute()
//                .Files
//                .Where(x => x.Id == fileId);

//            foreach (var file in files)
//            {
//                Console.WriteLine("{0} ({1})", file.Name, file.Id);

//                var request = service.Files.Export(file.Id, "text/csv");
//                var stream = new MemoryStream();
//                // Add a handler which will be notified on progress changes.
//                // It will notify on each chunk download and when the
//                // download is completed or failed.
//                request.MediaDownloader.ProgressChanged +=
//                    progress =>
//                    {
//                        switch (progress.Status)
//                        {
//                            case DownloadStatus.Downloading:
//                                {
//                                    Console.WriteLine(progress.BytesDownloaded);
//                                    break;
//                                }

//                            case DownloadStatus.Completed:
//                                {
//                                    Console.WriteLine("Download complete.");
//                                    break;
//                                }

//                            case DownloadStatus.Failed:
//                                {
//                                    Console.WriteLine("Download failed.");
//                                    break;
//                                }
//                        }
//                    };


//                request.Download(stream);
//                using (var file1 = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
//                {
//                    stream.WriteTo(file1);
//                }

//                using (var fil2 = new FileStream(destinationPath, FileMode.Open, FileAccess.Read))
//                {
//                    var reader = new StreamReader(fil2);
//                    var configuration = new Configuration
//                    {
//                        HasHeaderRecord = true,
//                        BadDataFound = null,
//                        Delimiter = ","
//                    };
//                    using (var csv = new CsvReader(reader, configuration))
//                    {
//                        var records = new List<InputDto>();
//                        csv.Read();
//                        csv.ReadHeader();
//                        while (csv.Read())
//                        {
//                            var i = 0;
//                            var record = new InputDto
//                            {
//                                TimeStamp = csv.GetField<string>(i++),
//                                KontaktpersonNavn = csv.GetField<string>(i++),
//                                KontaktpersonTelefon = csv.GetField<string>(i++),
//                                KontaktpersonEmail = csv.GetField<string>(i++),
//                                SkoleInstitutionNavn = csv.GetField<string>(i++),
//                                Deltagergruppe = csv.GetField<string>(i++),
//                                DeltagereAldersinterval = csv.GetField<string>(i++),
//                                DeltagereAntal = csv.GetField<string>(i++),
//                                OensketArrangement = csv.GetField<string>(i++),
//                                OensketMoedested = csv.GetField<string>(i++),
//                                OensketHvornaar = csv.GetField<string>(i++),
//                                OensketDatoForAfholdelse = csv.GetField<string>(i++),
//                                Bemaerkninger = csv.GetField<string>(i++),
//                                InstitutionEllerSkole = csv.GetField<string>(i)
//                            };
//                            records.Add(record);
//                        }
//                    }
//                }
//            }
//        }

//        private static UserCredential GetUserCredentials()
//        {
//            UserCredential credential;

//            using (var stream =
//                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
//            {
//                // The file token.json stores the user's access and refresh tokens, and is created
//                // automatically when the authorization flow completes for the first time.
//                var credPath = "token.json";
//                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
//                    GoogleClientSecrets.Load(stream).Secrets,
//                    Scopes,
//                    "user",
//                    CancellationToken.None,
//                    new FileDataStore(credPath, true)).Result;
//                Console.WriteLine("Credential file saved to: " + credPath);
//            }

//            return credential;
//        }
//    }
//}