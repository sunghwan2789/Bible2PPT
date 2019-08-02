using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bible2PPT.Bibles;

namespace Bible2PPT.PPT
{
    class BuildProgress
    {
        public int ItemsLeft { get; set; }

        public Job Job { get; set; }

        public Chapter CurrentChapter { get; set; }
    }
}
