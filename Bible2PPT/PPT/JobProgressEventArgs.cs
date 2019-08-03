using System;
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

        public int UnresolvedBooks { get; }
        public int UnresolvedChapters { get; }
        public int ResolvedChapters { get; }

        public JobProgressEventArgs(Job job)
        {
            Job = job;
        }
    }
}
