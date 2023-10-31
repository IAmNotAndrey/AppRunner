using AppRunner;
using CommandLine;
using CommandLine.Text;

class Program
{
	const int timeoutInSeconds = 1000;

	static void Main(string[] args)
	{
		CommandParser parser = new();
		Logger? logger;
		var cmdParseResult = parser.Parse(args);

		if (cmdParseResult.Output.LogFilePath is not null
			&& Path.GetExtension(cmdParseResult.Output.LogFilePath) == ".lst"
		)
			logger = new(cmdParseResult.Output.LogFilePath);
		else
			logger = null;

        Console.WriteLine("--- Start ---");
		logger?.Log("--- Start ---");
		// Одиночный режим
		if (cmdParseResult.Output.ExecFilePath is not null)
		{
			AppRunner.AppRunner app = new();
			
			// Подписка на уведомления
			app.LogNotify += ConsoleWriter.Log;
			if (logger is not null)
				app.LogNotify += logger.Log;

			app.RunExecutable(cmdParseResult.Output.ExecFilePath, timeoutInSeconds);
		}
		// Пакетный режим
		else if (cmdParseResult.Output.LstFilePath is not null)
		{
			string[] paths = File.ReadAllLines(cmdParseResult.Output.LstFilePath);

			foreach ( string path in paths ) 
			{
				AppRunner.AppRunner app = new();

				app.LogNotify += ConsoleWriter.Log;
				if (logger is not null)
					app.LogNotify += logger.Log;

				app.RunExecutable(path, timeoutInSeconds);
			}
		}

        Console.WriteLine("--- Stop ---");
        logger?.Log("--- Stop ---");
		logger?.Dispose();
	}
}