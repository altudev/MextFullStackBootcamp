using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class GoogleObjectStorageManager:IObjectStorageService
    {
        public Task<string> UploadImageAsync(byte[] imageData, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
