namespace Smile;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void LogError(string message)
    {
        LogHelper(message, LogLevel.Error, ConsoleColor.Red);
    }

    private static void LogHelper(string message, LogLevel logLevel, ConsoleColor color)
    {
        var curColor = Console.BackgroundColor;
        Console.BackgroundColor = color;
        Console.Write($"{logLevel.ToString()}: ");
        Console.BackgroundColor = curColor;
        Console.Write(message);
        Console.WriteLine();
    }

    public void LogInfo(string message)
    {
        LogHelper(message, LogLevel.Info, ConsoleColor.Green);
    }
}

