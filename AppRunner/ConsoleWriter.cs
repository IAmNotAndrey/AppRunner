namespace AppRunner;

public class ConsoleWriter
{
	public static void Log(object sender, LogEventArgs logArgs)
	{
		Console.WriteLine($"[{logArgs.DateTime}] {logArgs.Message}");
	}
}
