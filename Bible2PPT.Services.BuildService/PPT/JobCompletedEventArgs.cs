namespace Bible2PPT.PPT;

public class JobCompletedEventArgs : EventArgs
{
    public JobCompletedEventArgs(Job job, Exception? exception = default)
    {
        Job = job;
        Exception = exception;
    }

    public Job Job { get; }
    public Exception? Exception { get; }
    public bool IsFaulted => Exception is not null;
    public bool IsCancelled => Exception is OperationCanceledException;
}
