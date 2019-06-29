using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class BuildResult
    {
        public Work Work { get; set; }
        
        public bool IsCompleted { get; set; }

        public Exception Exception { get; set; }
    }
}
