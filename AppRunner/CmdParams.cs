﻿using CommandLine;

namespace AppRunner;

public class CmdParams
{
	[Option("path", Required = true, HelpText = "Exec file path")]
	public string? ExecFilePath { get; set; }

	[Option("lst", Required = false, HelpText = "Lst file path")]
	public string? LstFilePath { get; set; }

	[Option("trace", Required = false, HelpText = "Log File path")]
	public string? LogFilePath { get; set; }
}