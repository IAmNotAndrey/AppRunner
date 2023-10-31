namespace AppRunner;

public class TaskResult<T>
{
	public T Output { get; set; } = default!;
	public ExecutionResult ExecutionResult { get; set; }
}
