using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bible2PPT.PPT
{
    class JobAddedEventArgs : EventArgs
    {
        public Job Job { get; }
        public CancellationTokenSource CancellationTokenSource { get; }

        public JobAddedEventArgs(Job job, CancellationTokenSource cts)
        {
            Job = job;
            CancellationTokenSource = cts;
        }
    }
}
