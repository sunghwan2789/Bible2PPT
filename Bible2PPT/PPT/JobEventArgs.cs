using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class JobEventArgs : EventArgs
    {
        public Job Job { get; }

        public JobEventArgs(Job job)
        {
            Job = job;
        }
    }
}
