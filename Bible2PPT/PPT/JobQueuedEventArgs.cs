using System;

namespace Bible2PPT.PPT
{
    class JobQueuedEventArgs : EventArgs
    {
        public Job Job { get; }

        public JobQueuedEventArgs(Job job)
        {
            Job = job;
        }
    }
}
