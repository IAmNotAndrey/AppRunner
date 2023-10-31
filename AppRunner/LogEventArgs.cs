using System;

namespace AppRunner;

public class LogEventArgs : EventArgs
{
	public string? Message { get; set; }
	public DateTime DateTime { get; set; }

    public LogEventArgs(string? message)
    {
		Message = message;
		DateTime = DateTime.Now;
	}
    public LogEventArgs(string? message, DateTime dateTime)
    {
        Message = message;
        DateTime = dateTime;
    }
}
