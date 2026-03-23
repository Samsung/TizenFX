using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Tizen.NUI.BaseComponents;

namespace Tizen.Benchmark.Gallery
{
    /// <summary>
    /// Benchmarks comparing Marshal.AllocHGlobal vs stackalloc/fixed patterns
    /// for native interop struct marshaling.
    /// </summary>
    public static class StackallocBenchmark
    {
        private const int Iterations = 100_000;

        // Simulated blittable struct (matches CkmcRawBuffer: IntPtr + UIntPtr)
        [StructLayout(LayoutKind.Sequential)]
        private struct RawBuffer
        {
            public IntPtr data;
            public UIntPtr size;

            public RawBuffer(IntPtr data, int size)
            {
                this.data = data;
                this.size = (UIntPtr)size;
            }
        }

        // Simulated blittable struct (matches Coordinate: double × 2)
        [StructLayout(LayoutKind.Sequential)]
        private struct Coordinate
        {
            public double Latitude;
            public double Longitude;
        }

        /// <summary>
        /// Single struct: Marshal.AllocHGlobal + StructureToPtr + FreeHGlobal (old pattern)
        /// </summary>
        public static (long elapsed, string result) RunSingleStructOld()
        {
            var sw = Stopwatch.StartNew();

            for (int iter = 0; iter < Iterations; iter++)
            {
                var buf = new RawBuffer(IntPtr.Zero, 1024);
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<RawBuffer>());
                try
                {
                    Marshal.StructureToPtr(buf, ptr, false);
                    // Simulate native call reading from ptr
                    var readBack = Marshal.PtrToStructure<RawBuffer>(ptr);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }

            sw.Stop();
            string result = $"Single Struct (AllocHGlobal): {sw.ElapsedMilliseconds}ms / {Iterations} iterations";
            return (sw.ElapsedMilliseconds, result);
        }

        /// <summary>
        /// Single struct: stackalloc (new pattern)
        /// </summary>
        public static unsafe (long elapsed, string result) RunSingleStructNew()
        {
            var sw = Stopwatch.StartNew();

            for (int iter = 0; iter < Iterations; iter++)
            {
                var buf = new RawBuffer(IntPtr.Zero, 1024);
                RawBuffer* ptr = stackalloc RawBuffer[1];
                *ptr = buf;
                // Simulate native call reading from ptr
                var readBack = *ptr;
            }

            sw.Stop();
            string result = $"Single Struct (stackalloc):   {sw.ElapsedMilliseconds}ms / {Iterations} iterations";
            return (sw.ElapsedMilliseconds, result);
        }

        /// <summary>
        /// Array of structs: Marshal.AllocHGlobal + StructureToPtr loop (old pattern)
        /// </summary>
        public static (long elapsed, string result) RunStructArrayOld()
        {
            const int arraySize = 50;
            var coords = new Coordinate[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                coords[i] = new Coordinate { Latitude = i * 1.1, Longitude = i * 2.2 };
            }

            var sw = Stopwatch.StartNew();

            for (int iter = 0; iter < Iterations; iter++)
            {
                int structSize = Marshal.SizeOf<Coordinate>();
                IntPtr listPointer = Marshal.AllocHGlobal(structSize * arraySize);
                try
                {
                    for (int i = 0; i < arraySize; i++)
                    {
                        Marshal.StructureToPtr(coords[i], listPointer + i * structSize, false);
                    }
                    // Simulate native call reading from listPointer
                    var readBack = Marshal.PtrToStructure<Coordinate>(listPointer);
                }
                finally
                {
                    Marshal.FreeHGlobal(listPointer);
                }
            }

            sw.Stop();
            string result = $"Struct Array[{arraySize}] (AllocHGlobal): {sw.ElapsedMilliseconds}ms / {Iterations} iterations";
            return (sw.ElapsedMilliseconds, result);
        }

        /// <summary>
        /// Array of structs: fixed pinning (new pattern)
        /// </summary>
        public static unsafe (long elapsed, string result) RunStructArrayNew()
        {
            const int arraySize = 50;
            var coords = new Coordinate[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                coords[i] = new Coordinate { Latitude = i * 1.1, Longitude = i * 2.2 };
            }

            var sw = Stopwatch.StartNew();

            for (int iter = 0; iter < Iterations; iter++)
            {
                fixed (Coordinate* listPointer = coords)
                {
                    // Simulate native call reading from listPointer
                    var readBack = *listPointer;
                }
            }

            sw.Stop();
            string result = $"Struct Array[{arraySize}] (fixed):       {sw.ElapsedMilliseconds}ms / {Iterations} iterations";
            return (sw.ElapsedMilliseconds, result);
        }

        #region UI Wrappers (Action<TextLabel> compatible)

        public static void RunSingleStructOldUI(TextLabel resultLabel)
        {
            var (_, result) = RunSingleStructOld();
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        public static void RunSingleStructNewUI(TextLabel resultLabel)
        {
            var (_, result) = RunSingleStructNew();
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        public static void RunStructArrayOldUI(TextLabel resultLabel)
        {
            var (_, result) = RunStructArrayOld();
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        public static void RunStructArrayNewUI(TextLabel resultLabel)
        {
            var (_, result) = RunStructArrayNew();
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        public static void RunAllUI(TextLabel resultLabel)
        {
            var result = RunAll();
            resultLabel.Text += result;
        }

        #endregion

        /// <summary>
        /// Run all benchmarks and return formatted results
        /// </summary>
        public static string RunAll()
        {
            var allResults = new global::System.Text.StringBuilder();

            void Log(string line)
            {
                allResults.AppendLine(line);
                Console.WriteLine(line);
            }

            Log("=== Span/stackalloc Benchmark ===");
            Log($"Iterations: {Iterations:N0}");
            Log("");

            // Warmup
            RunSingleStructOld();
            RunSingleStructNew();
            RunStructArrayOld();
            RunStructArrayNew();

            // Single struct benchmark
            Log("--- Single Struct (CkmcRawBuffer pattern) ---");
            var (oldMs1, oldResult1) = RunSingleStructOld();
            var (newMs1, newResult1) = RunSingleStructNew();
            Log(oldResult1);
            Log(newResult1);
            if (oldMs1 > 0)
            {
                double improvement1 = (1.0 - (double)newMs1 / oldMs1) * 100;
                Log($"→ stackalloc is {improvement1:F1}% faster");
            }
            Log("");

            // Array benchmark
            Log("--- Struct Array (Coordinate[] pattern) ---");
            var (oldMs2, oldResult2) = RunStructArrayOld();
            var (newMs2, newResult2) = RunStructArrayNew();
            Log(oldResult2);
            Log(newResult2);
            if (oldMs2 > 0)
            {
                double improvement2 = (1.0 - (double)newMs2 / oldMs2) * 100;
                Log($"→ fixed is {improvement2:F1}% faster");
            }

            return allResults.ToString();
        }
    }
}
