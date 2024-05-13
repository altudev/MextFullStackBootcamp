namespace MextFullStack.ConsoleClient
{
    public abstract class LoggerBase
    {
        public LoggerBase(string name, LogType logType)
        {
            Name = name;

            Console.WriteLine($"LoggerBase Constructor: {name} - {logType}");
        }
        public string Name { get; set; }

        public virtual void Log(string message, LogType logType)
        {
            Console.WriteLine($"LoggerBase Log: {message} - {logType}");
        }
    }
}
