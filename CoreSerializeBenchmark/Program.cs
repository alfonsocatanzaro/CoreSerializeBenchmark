using System;
using System.Diagnostics;
using System.Threading;

namespace CoreSerializeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 1000;

            Thread.Sleep(5000);
            ConsoleKeyInfo a = new ConsoleKeyInfo();
            do
            {
                Console.Clear();

                stringBinaryStandard(iterations, "DotNet standardLibrary from DotNetCore - BinarySerialize of strings");
                stringNewtonSoftJsonStandard(iterations, "DotNet standardLibrary from DotNetCore - Json(NewtonSoft)Serialize of strings");


                Console.WriteLine("-------------");

                stringBinaryCore(iterations, "DotNetCore - BinarySerialize of strings");
                stringNewtonSoftJsonCore(iterations, "DotNetCore - Json(NewtonSoft)Serialize of strings");

                a = Console.ReadKey();

            } while (a.Key != ConsoleKey.Escape);

        }


        private static void stringBinaryStandard(int iterations, string title)
        {
            Console.WriteLine(title);
            NetStandardLibrarySerializer.BinarySerializer<string> stringBinarySerializer = new NetStandardLibrarySerializer.BinarySerializer<string>();
            string[] dataToSerialize = new string[iterations];
            for (int i = 0; i < iterations; i++)
                dataToSerialize[i] = $"{i + 1} of {iterations}";

            byte[][] serialized = new byte[iterations][];

            Stopwatch sp = new Stopwatch();

            sp.Start();
            for (int i = 0; i < iterations; i++)
                serialized[i] = stringBinarySerializer.Serialize(dataToSerialize[i]);
            sp.Stop();
            Console.WriteLine($"Serialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");


            string[] deserialized = new string[iterations];
            sp.Restart();
            for (int i = 0; i < iterations; i++)
                deserialized[i] = stringBinarySerializer.Deserialize(serialized[i]);
            sp.Stop();

            Console.WriteLine($"Deserialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");
        }

        private static void stringNewtonSoftJsonStandard(int iterations, string title)
        {
            Console.WriteLine(title);
            NetStandardLibrarySerializer.NewtonSoftJsonSerializer<string> stringJsonSerializer = new NetStandardLibrarySerializer.NewtonSoftJsonSerializer<string>();
            string[] dataToSerialize = new string[iterations];
            for (int i = 0; i < iterations; i++)
                dataToSerialize[i] = $"{i + 1} of {iterations}";

            string[] serialized = new string[iterations];

            Stopwatch sp = new Stopwatch();

            sp.Start();
            for (int i = 0; i < iterations; i++)
                serialized[i] = stringJsonSerializer.Serialize(dataToSerialize[i]);
            sp.Stop();
            Console.WriteLine($"Serialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");


            string[] deserialized = new string[iterations];
            sp.Restart();
            for (int i = 0; i < iterations; i++)
                deserialized[i] = stringJsonSerializer.Deserialize(serialized[i]);
            sp.Stop();

            Console.WriteLine($"Deserialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");
        }

        private static void stringBinaryCore(int iterations, string title)
        {
            Console.WriteLine(title);
            CoreSerializeBenchmark.lib.BinarySerializer<string> stringBinarySerializer = new CoreSerializeBenchmark.lib.BinarySerializer<string>();
            string[] dataToSerialize = new string[iterations];
            for (int i = 0; i < iterations; i++)
                dataToSerialize[i] = $"{i + 1} of {iterations}";

            byte[][] serialized = new byte[iterations][];

            Stopwatch sp = new Stopwatch();

            sp.Start();
            for (int i = 0; i < iterations; i++)
                serialized[i] = stringBinarySerializer.Serialize(dataToSerialize[i]);
            sp.Stop();
            Console.WriteLine($"Serialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");


            string[] deserialized = new string[iterations];
            sp.Restart();
            for (int i = 0; i < iterations; i++)
                deserialized[i] = stringBinarySerializer.Deserialize(serialized[i]);
            sp.Stop();

            Console.WriteLine($"Deserialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");
        }

        private static void stringNewtonSoftJsonCore(int iterations, string title)
        {
            Console.WriteLine(title);
            CoreSerializeBenchmark.lib.NewtonSoftJsonSerializer<string> stringJsonSerializer = new CoreSerializeBenchmark.lib.NewtonSoftJsonSerializer<string>();
            string[] dataToSerialize = new string[iterations];
            for (int i = 0; i < iterations; i++)
                dataToSerialize[i] = $"{i + 1} of {iterations}";

            string[] serialized = new string[iterations];

            Stopwatch sp = new Stopwatch();

            sp.Start();
            for (int i = 0; i < iterations; i++)
                serialized[i] = stringJsonSerializer.Serialize(dataToSerialize[i]);
            sp.Stop();
            Console.WriteLine($"Serialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");


            string[] deserialized = new string[iterations];
            sp.Restart();
            for (int i = 0; i < iterations; i++)
                deserialized[i] = stringJsonSerializer.Deserialize(serialized[i]);
            sp.Stop();

            Console.WriteLine($"Deserialization of {iterations} strings: {sp.ElapsedMilliseconds} ms");
        }
    }
}
