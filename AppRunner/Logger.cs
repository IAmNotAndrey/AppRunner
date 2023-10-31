namespace AppRunner;

public class Logger : IDisposable
{
	private StreamWriter _logStreamWriter;

	public Logger(string logFilePath)
	{
		_logStreamWriter = new StreamWriter(logFilePath);
	} 

	public void Log(string message)
	{
		_logStreamWriter.WriteLine(message);
	}

	public void Log(object sender, LogEventArgs logArgs)
	{
		_logStreamWriter.WriteLine($"[{logArgs.DateTime}] {logArgs.Message}");
	}

	public void Dispose()
	{
		_logStreamWriter.Close();	
	}
}
