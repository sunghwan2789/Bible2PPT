using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class JobCompletedEventArgs : JobEventArgs
    {
        public BuildResult Result { get; }

        public JobCompletedEventArgs(Job job, BuildResult result) : base(job)
        {
            Result = result;
        }
    }
}
