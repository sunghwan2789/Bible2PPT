using System;

namespace Bible2PPT.PPT
{
    class JobCompletedEventArgs : EventArgs
    {
        public Job Job { get; }
        public Exception Exception { get; }
        public bool IsFaulted => Exception != null;
        public bool IsCancelled => Exception is OperationCanceledException;

        public JobCompletedEventArgs(Job job, Exception ex)
        {
            Job = job;
            Exception = ex;
        }
    }
}
