namespace MextFullStack.ConsoleClient
{
    public class ConsoleLogger : LoggerBase
    {
        public string ConsoleColour { get; set; }
        public ConsoleLogger(string name, string consoleColour,LogType logType) :base(name,logType)
        {
            ConsoleColour = consoleColour;
        }
        
    }
}
