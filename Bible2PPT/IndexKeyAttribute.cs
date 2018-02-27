using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT
{
    class IndexKeyAttribute : Attribute
    {
        public int Order = int.MaxValue;
        public string Name = "IDX";
        public bool Ascending = true;
    }
}
