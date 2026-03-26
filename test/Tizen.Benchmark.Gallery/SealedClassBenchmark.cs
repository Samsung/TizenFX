/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.Benchmark.Gallery
{
    /// <summary>
    /// Benchmarks comparing virtual method dispatch on non-sealed vs sealed classes.
    /// Sealed classes allow the JIT compiler to devirtualize virtual method calls,
    /// converting indirect calls to direct calls and enabling inlining.
    /// </summary>
    internal static class SealedClassBenchmark
    {
        private const int Iterations = 5_000_000;

        // --- Base class with virtual method ---
        private class BaseHandler
        {
            public virtual int Process(int value) => value * 2 + 1;
        }

        // --- Non-sealed derived class (old pattern) ---
        private class NonSealedHandler : BaseHandler
        {
            public override int Process(int value) => value * 2 + 1;
        }

        // --- Sealed derived class (new pattern — JIT can devirtualize) ---
        private sealed class SealedHandler : BaseHandler
        {
            public override int Process(int value) => value * 2 + 1;
        }

        // --- Interface-based pattern (common in TizenFX) ---
        private interface IHandler
        {
            int Process(int value);
        }

        private class NonSealedInterfaceHandler : IHandler
        {
            public int Process(int value) => value * 2 + 1;
        }

        private sealed class SealedInterfaceHandler : IHandler
        {
            public int Process(int value) => value * 2 + 1;
        }

        /// <summary>
        /// Benchmark: Virtual method call on non-sealed class
        /// </summary>
        public static void RunVirtualNonSealedUI(TextLabel resultLabel)
        {
            BaseHandler handler = new NonSealedHandler();

            // Warmup
            for (int i = 0; i < 1000; i++) handler.Process(i);

            var sw = Stopwatch.StartNew();
            long sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += handler.Process(i);
            }
            sw.Stop();

            string result = $"Virtual (non-sealed): {sw.ElapsedMilliseconds}ms / {Iterations / 1_000_000}M iters (sum={sum})";
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        /// <summary>
        /// Benchmark: Virtual method call on sealed class (JIT can devirtualize)
        /// </summary>
        public static void RunVirtualSealedUI(TextLabel resultLabel)
        {
            BaseHandler handler = new SealedHandler();

            // Warmup
            for (int i = 0; i < 1000; i++) handler.Process(i);

            var sw = Stopwatch.StartNew();
            long sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += handler.Process(i);
            }
            sw.Stop();

            string result = $"Virtual (sealed):     {sw.ElapsedMilliseconds}ms / {Iterations / 1_000_000}M iters (sum={sum})";
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        /// <summary>
        /// Benchmark: Interface dispatch on non-sealed class
        /// </summary>
        public static void RunInterfaceNonSealedUI(TextLabel resultLabel)
        {
            IHandler handler = new NonSealedInterfaceHandler();

            // Warmup
            for (int i = 0; i < 1000; i++) handler.Process(i);

            var sw = Stopwatch.StartNew();
            long sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += handler.Process(i);
            }
            sw.Stop();

            string result = $"Interface (non-sealed): {sw.ElapsedMilliseconds}ms / {Iterations / 1_000_000}M iters (sum={sum})";
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }

        /// <summary>
        /// Benchmark: Interface dispatch on sealed class (JIT can devirtualize)
        /// </summary>
        public static void RunInterfaceSealedUI(TextLabel resultLabel)
        {
            IHandler handler = new SealedInterfaceHandler();

            // Warmup
            for (int i = 0; i < 1000; i++) handler.Process(i);

            var sw = Stopwatch.StartNew();
            long sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += handler.Process(i);
            }
            sw.Stop();

            string result = $"Interface (sealed):     {sw.ElapsedMilliseconds}ms / {Iterations / 1_000_000}M iters (sum={sum})";
            resultLabel.Text += result + "\n";
            Console.WriteLine(result);
        }
    }
}
