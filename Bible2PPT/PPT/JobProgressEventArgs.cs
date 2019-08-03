﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bible2PPT.PPT
{
    class JobProgressEventArgs : EventArgs
    {
        public Job Job { get; }
        public CancellationTokenSource CancellationTokenSource { get; }

        public JobProgressEventArgs(Job job, CancellationTokenSource cts)
        {
            Job = job;
            CancellationTokenSource = cts;
        }
    }
}
