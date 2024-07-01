using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class GoogleObjectStorageManager:IObjectStorageService
    {
        private const string BucketName = "iconbuilderai-icons-us";
        private readonly GoogleCredential _credential;

        public GoogleObjectStorageManager()
        {
            _credential = GoogleCredential.FromFile("C:\\Users\\alper\\Desktop\\fullstack-yt-app-d3288d4031f5.json");
        }
        public async Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken)
        {
            // Convert the base64 string to byte array
            var imageBytes = Convert.FromBase64String(imageData);

            // Create a new MemoryStream
            using var imageStream = new MemoryStream(imageBytes);

            // Create a new Google Cloud Storage client
            using var storage = await StorageClient.CreateAsync(_credential);

            // Generate a unique filename
            string fileName = $"{Guid.NewGuid()}.jpg";

            // Upload the file to Google Cloud Storage
            var uploadedObject = await storage.UploadObjectAsync(
                BucketName,
                fileName,
                "image/jpeg",
                imageStream,
                cancellationToken: cancellationToken);

            // Return the public URL of the uploaded image
            //return $"https://storage.googleapis.com/{BucketName}/{fileName}";
            //return $"https://storage.googleapis.com/iconbuilderai-icons-us/{fileName}";
            return fileName;


        }

        public async Task<List<string>> UploadImagesAsync(List<string> imagesData, CancellationToken cancellationToken)
        {
            var uploadTasks = imagesData.Select(imageData => UploadImageAsync(imageData, cancellationToken));

            var results = await Task.WhenAll(uploadTasks);

            return results.ToList();
        }
    }
}
