namespace Bible2PPT.PPT;

public class JobQueuedEventArgs : EventArgs
{
    public JobQueuedEventArgs(Job job)
    {
        Job = job;
    }

    public Job Job { get; }
}
