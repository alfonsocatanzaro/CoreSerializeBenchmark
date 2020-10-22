using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CoreSerializeBenchmark.lib
{
    public class BinarySerializer<T> : ISerializer<T, byte[]>
    {


        private BinaryFormatter _binaryFormatter;

        public BinarySerializer()
        {
            this._binaryFormatter = new BinaryFormatter();
        }

        public T Deserialize(byte[] data)
        {
            T result;
            using (Stream stream = new MemoryStream(data))
            {
                result = (T)_binaryFormatter.Deserialize(stream);
            }
            return result;
        }

        public byte[] Serialize(T obj)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                _binaryFormatter.Serialize(memoryStream, obj);
                result = memoryStream.ToArray();
            }
            return result;
        }
    }
}
