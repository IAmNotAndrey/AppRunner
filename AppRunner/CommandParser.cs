using CommandLine;
using CommandLine.Text;

namespace AppRunner;

public class CommandParser
{
	public TaskResult<CmdParams> Parse(string[] args)
	{
		TaskResult<CmdParams> output = new();

		args = args
			.Select(x => x.Replace("/", "--"))
			.ToArray();

		Parser.Default.ParseArguments<CmdParams>(args)
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

                Console.WriteLine("OK");
                output.Output = options;
				output.ExecutionResult = ExecutionResult.OK;

				return;
			})
			.WithNotParsed(errors =>
			{
                Console.WriteLine("[-] NotParsed");
            });

		return default;
	}
}
