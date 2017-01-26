using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT
{
    interface IConfig
    {
        byte Serialize();
        void Deserialize(byte s);
    }
}
