using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveApiv3
{
    public class GoogleDriveFilesRepository
    {
        public static string[] Scopes = { DriveService.Scope.Drive };

        public static DriveService GetService()
        {
            UserCredential userCredential;

            using (var stream = new FileStream(@"D:\drive\client_secret_1070104748774-cfe7mfhsr84kn7gqgn1hfaojn7a046op.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                string folderPath = @"D:\drive\";
                string filePath = Path.Combine(folderPath, "DriveServiceCredentials.json");
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", System.Threading.CancellationToken.None, new FileDataStore(filePath, true)).Result;
            }

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = userCredential,
                ApplicationName = "DemoGoogleDriveAPI"
            });
            return service;
        }

        public static string UploadFile(string pathImage)
        {
            var name = Guid.NewGuid();
            DriveService driveService = GetService();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = name + ".jpg"
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(pathImage,
                                    System.IO.FileMode.Open))
            {
                request = driveService.Files.Create(
                    fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }
            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
            return file.Id;
        }

        public static Stream DownloadFile(string fileId)
        {
            DriveService service = GetService();
            var request = service.Files.Get(fileId);
            var stream = new MemoryStream();
            request.MediaDownloader.ProgressChanged +=
    (IDownloadProgress progress) =>
    {
        switch (progress.Status)
        {
            case DownloadStatus.Downloading:
                {
                    Console.WriteLine(progress.BytesDownloaded);
                    break;
                }
            case DownloadStatus.Completed:
                {
                    Console.WriteLine("Download complete.");
                    break;
                }
            case DownloadStatus.Failed:
                {
                    Console.WriteLine("Download failed.");
                    break;
                }
        }
    };
            request.Download(stream);
            return stream;
        }
    }
}
