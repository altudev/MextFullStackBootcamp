namespace MextFullStack.ConsoleClient
{
    public class FileLogger:LoggerBase
    {
        public FileLogger(string name):base(name,LogType.Debug)
        {
            
        }

        public override void Log(string message, LogType logType)
        {
            File.WriteAllText("C:\\Logs\\logs.txt",$"Log Tipi:{GetLogType(logType)}");

            base.Log(message, logType);
        }

        private string GetLogType(LogType logType)
        {
            return logType switch
            {
                LogType.Information => "Bilgi Seviyesi",
                LogType.Warning => "Uyari Seviyesi",
                LogType.Error => "Hata Seviyesi",
                LogType.Debug => "Hata Ayiklama Seviyesi",
                _ => "Bilgi Seviyesi"
            };
        }
    }
}
