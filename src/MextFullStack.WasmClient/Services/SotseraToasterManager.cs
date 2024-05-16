using Sotsera.Blazor.Toaster;

namespace MextFullStack.WasmClient.Services
{
    public class SotseraToasterManager: IToasterService
    {
        private readonly IToaster _toaster;

        public SotseraToasterManager(IToaster toaster)
        {
            _toaster = toaster;
        }

        public void ShowSuccess(string message)
        {
            _toaster.Success(message);
        }

        public void ShowWarning(string message)
        {
            _toaster.Warning(message);
        }

        public void ShowError(string message)
        {
            _toaster.Error(message);
        }

        public void ShowInfo(string message)
        {
            _toaster.Info(message);
        }
    }
}
