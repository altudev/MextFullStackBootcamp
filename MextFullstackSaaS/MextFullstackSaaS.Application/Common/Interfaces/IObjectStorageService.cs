namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IObjectStorageService
    {
        Task<string> UploadImageAsync(byte[] imageData, CancellationToken cancellationToken);
        
    }
}
