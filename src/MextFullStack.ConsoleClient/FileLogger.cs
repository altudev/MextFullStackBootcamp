namespace MextFullStack.ConsoleClient
{
    public class FileLogger:LoggerBase
    {
        public FileLogger(string name):base(name,LogType.Debug)
        {
            
        }

        public override void Log(string message, LogType logType)
        {
            File.WriteAllText("C:\\Logs\\logs.txt",message);

            base.Log(message, logType);
        }
    }
}
