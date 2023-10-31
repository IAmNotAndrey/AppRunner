using AppRunner;
using CommandLine;
using CommandLine.Text;

class Program
{
	static void Main(string[] args)
	{
		CommandParser parser = new ();
		var a = parser.Parse(args);
	}
}