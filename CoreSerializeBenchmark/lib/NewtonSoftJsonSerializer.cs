using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSerializeBenchmark.lib
{
    public class NewtonSoftJsonSerializer<T> : ISerializer<T, string>
    {
        public T Deserialize(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
