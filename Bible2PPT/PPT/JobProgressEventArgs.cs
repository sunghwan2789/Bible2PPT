using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class JobProgressEventArgs : JobEventArgs
    {
        public JobProgressEventArgs(Job job) : base(job)
        {

        }
    }
}
