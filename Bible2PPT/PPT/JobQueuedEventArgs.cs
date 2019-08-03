using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

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
