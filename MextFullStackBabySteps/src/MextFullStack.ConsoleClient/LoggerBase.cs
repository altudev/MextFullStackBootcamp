using MextFullStack.Domain.Common;

namespace MextFullStack.ConsoleClient
{
    public abstract class LoggerBase
    {
        public LoggerBase(string name, LogType logType)
        {
            Name = name;

            Console.WriteLine($"LoggerBase Constructor: {name} - {logType}");
        }
        protected string Name { get; set; }

        public virtual void Log(string message, LogType logType)
        {
            Console.WriteLine($"LoggerBase Log: {message} - {logType}");
        }

        protected static string GetLogType(LogType logType)
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
