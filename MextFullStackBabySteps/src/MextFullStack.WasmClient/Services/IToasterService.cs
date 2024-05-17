namespace MextFullStack.WasmClient.Services
{
    public interface IToasterService
    {
        void ShowSuccess(string message);
        void ShowWarning(string message);
        void ShowError(string message);
        void ShowInfo(string message);
    }
}
