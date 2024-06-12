using Blazored.Toast.Services;

namespace MextFullstackSaaS.WasmClient.Services
{
    public class BlazoredToasterManager : IToasterService
    {
        private readonly IToastService _toastService;

        public BlazoredToasterManager(IToastService toastService)
        {
            _toastService = toastService;
        }

        public void ShowSuccess(string message)
        {
            _toastService.ShowSuccess(message);
        }

        public void ShowWarning(string message)
        {
            _toastService.ShowWarning(message);
        }

        public void ShowError(string message)
        {
            _toastService.ShowError(message);
        }

        public void ShowInfo(string message) => _toastService.ShowInfo(message);

    }
}
