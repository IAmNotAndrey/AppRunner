using CommandLine;
using CommandLine.Text;

namespace AppRunner;

public class CommandParser
{
	public TaskResult<CommandLineParams> Parse(string[] args)
	{
		TaskResult<CommandLineParams> output = new();

		args = args
			.Select(x => x.Replace("/", "--"))
			.ToArray();

		Parser.Default.ParseArguments<CommandLineParams>(args)
			.WithParsed(options =>
			{
				// Проверка взаимоисключающих опций
				if (!string.IsNullOrWhiteSpace(options.ExecFilePath) && !string.IsNullOrWhiteSpace(options.LstFilePath))
				{
					Console.WriteLine("Error: /path и /lst cannot be assigned at the same time.");

					output.Output = options;
					output.ExecutionResult = ExecutionResult.INVALID_SYNTAX;

					return;
				}

				output.Output = options;
				output.ExecutionResult = ExecutionResult.OK;

				return;
			})
			.WithNotParsed(errors =>
			{
				
				
			});

		return default;
	}
}
