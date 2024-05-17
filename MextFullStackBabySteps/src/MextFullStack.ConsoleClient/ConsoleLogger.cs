namespace MextFullStack.ConsoleClient
{
    public class ConsoleLogger : LoggerBase
    {
        public string ConsoleColour { get; set; }
        public ConsoleLogger(string name, string consoleColour,LogType logType) :base(name,logType)
        {
            ConsoleColour = consoleColour;

            Name = name;
        }

        override public void Log(string message, LogType logType)
        {
            Console.WriteLine($"Log Type:{GetLogType(logType)} - {message}");
            Console.ResetColor();
            base.Log(message, logType);
        }

        
    }
}
