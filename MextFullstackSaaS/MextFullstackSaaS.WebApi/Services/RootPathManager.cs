using MextFullstackSaaS.Application.Common.Interfaces;

namespace MextFullstackSaaS.WebApi.Services
{
    public class RootPathManager:IRootPathService
    {
        private readonly string _rootPath;

        public RootPathManager(string rootPath)
        {
            _rootPath = rootPath;
        }

        public string GetRootPath() => _rootPath;
    }
}
