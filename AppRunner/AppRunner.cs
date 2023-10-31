using System.Diagnostics;

namespace AppRunner;

public class AppRunner
{
	public event LogHandler LogNotify;

	public ExecutionResult RunExecutable(string filePath, int timeoutInSeconds)
	{
		if (!File.Exists(filePath))
		{
			LogNotify?.Invoke(this, new LogEventArgs(
				$"[{ExecutionResult.FAIL}] File `{filePath}` doesn't exist"
			));
			return ExecutionResult.FAIL;
		}

		var processInfo = new ProcessStartInfo
		{
			FileName = filePath,
		};
		using var process = new Process { StartInfo = processInfo };
		process.Start();

		// Дождемся завершения процесса, но не более чем timeoutInSeconds секунд
		if (process.WaitForExit(timeoutInSeconds))
		{
			if (process.ExitCode == 0)
			{
				// Процесс успешно завершился
				LogNotify?.Invoke(this, new LogEventArgs(
					$"[{ExecutionResult.OK}] Process `{process}` has been finished"
				));
				return ExecutionResult.OK;
			}
			
			LogNotify?.Invoke(this, new LogEventArgs(
					$"[{ExecutionResult.ERRORS}] Error executing process `{process}`"
				));
			return ExecutionResult.ERRORS;
		}
		
		// Процесс не завершился вовремя
		LogNotify?.Invoke(this, new LogEventArgs(
			$"[{ExecutionResult.FAIL}] Process `{process}` timeout"
		));
		return ExecutionResult.FAIL;
	}
}
