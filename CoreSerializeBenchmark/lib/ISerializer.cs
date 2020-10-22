using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSerializeBenchmark.lib
{
    public interface ISerializer<Tin,Tout>
    {
        Tout Serialize(Tin obj);
        Tin Deserialize(Tout data);
    }
}
