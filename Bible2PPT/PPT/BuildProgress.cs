using Bible2PPT.Bibles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class BuildProgress
    {
        public int ItemsLeft { get; set; }

        public Work Work { get; set; }

        public Chapter CurrentChapter { get; set; }
    }
}
