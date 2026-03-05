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
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics;
using Tizen.NUI.BaseComponents;

namespace Tizen.Benchmark.Gallery
{
    /// <summary>
    /// Benchmark comparing Dictionary vs FrozenDictionary lookup performance.
    /// Simulates the actual TizenFX usage patterns (enum-to-type mappings, string-to-enum lookups, etc.)
    /// </summary>
    internal static class FrozenDictionaryBenchmark
    {
        private const int WarmupIterations = 1000;
        private const int BenchmarkIterations = 500_000;

        #region Test Data - String Key (simulates PropertyHelper, CustomViewRegistry patterns)

        private static readonly Dictionary<string, int> StringDictionary = new Dictionary<string, int>
        {
            { "backgroundColor", 1 }, { "backgroundOpacity", 2 },
            { "boxShadow.BlurRadius", 3 }, { "boxShadow.Color", 4 },
            { "boxShadow.CornerRadius", 5 }, { "boxShadow.Offset", 6 },
            { "borderlineWidth", 7 }, { "borderlineColor", 8 },
            { "borderlineOffset", 9 }, { "imageShadow.Offset", 10 },
            { "shadow.CornerRadius", 11 }, { "cornerRadius", 12 },
            { "float", 13 }, { "int", 14 }, { "Boolean", 15 },
        };

        private static readonly FrozenDictionary<string, int> StringFrozenDictionary =
            StringDictionary.ToFrozenDictionary();

        private static readonly string[] StringKeys =
        {
            "backgroundColor", "borderlineWidth", "cornerRadius",
            "float", "shadow.CornerRadius", // existing keys
            "nonExistentKey1", "nonExistentKey2", // miss keys
        };

        #endregion

        #region Test Data - Enum Key (simulates RuntimeInfo.s_keyDataTypeMapping pattern)

        private enum TestInfoKey
        {
            Bluetooth, WifiHotspot, BluetoothTethering, UsbTethering,
            PacketData, DataRoaming, Vibration, AudioJack,
            BatteryIsCharging, TvOut, Charger, AutoRotation,
            Gps, AudioJackConnector,
        }

        private static readonly Dictionary<TestInfoKey, Type> EnumDictionary = new Dictionary<TestInfoKey, Type>
        {
            [TestInfoKey.Bluetooth] = typeof(bool),
            [TestInfoKey.WifiHotspot] = typeof(bool),
            [TestInfoKey.BluetoothTethering] = typeof(bool),
            [TestInfoKey.UsbTethering] = typeof(bool),
            [TestInfoKey.PacketData] = typeof(bool),
            [TestInfoKey.DataRoaming] = typeof(bool),
            [TestInfoKey.Vibration] = typeof(bool),
            [TestInfoKey.AudioJack] = typeof(bool),
            [TestInfoKey.BatteryIsCharging] = typeof(bool),
            [TestInfoKey.TvOut] = typeof(bool),
            [TestInfoKey.Charger] = typeof(bool),
            [TestInfoKey.AutoRotation] = typeof(bool),
            [TestInfoKey.Gps] = typeof(int),
            [TestInfoKey.AudioJackConnector] = typeof(int),
        };

        private static readonly FrozenDictionary<TestInfoKey, Type> EnumFrozenDictionary =
            EnumDictionary.ToFrozenDictionary();

        private static readonly TestInfoKey[] EnumKeys =
        {
            TestInfoKey.Bluetooth, TestInfoKey.Gps, TestInfoKey.AudioJackConnector,
            TestInfoKey.Vibration, TestInfoKey.AutoRotation,
        };

        #endregion

        #region Test Data - Type Key (simulates BindableProperty.WellKnownConvertTypes pattern)

        private static readonly Dictionary<Type, string> TypeDictionary = new Dictionary<Type, string>
        {
            { typeof(int), "int" }, { typeof(float), "float" },
            { typeof(double), "double" }, { typeof(string), "string" },
            { typeof(bool), "bool" }, { typeof(byte), "byte" },
            { typeof(short), "short" }, { typeof(long), "long" },
            { typeof(decimal), "decimal" }, { typeof(char), "char" },
        };

        private static readonly FrozenDictionary<Type, string> TypeFrozenDictionary =
            TypeDictionary.ToFrozenDictionary();

        private static readonly Type[] TypeKeys =
        {
            typeof(int), typeof(string), typeof(float),
            typeof(bool), typeof(decimal),
        };

        #endregion

        public static void RunStringKeyLookup(TextLabel resultLabel)
        {
            RunBenchmark(
                resultLabel,
                "String Key TryGetValue",
                StringDictionary,
                StringFrozenDictionary,
                StringKeys
            );
        }

        public static void RunEnumKeyLookup(TextLabel resultLabel)
        {
            RunBenchmark(
                resultLabel,
                "Enum Key TryGetValue",
                EnumDictionary,
                EnumFrozenDictionary,
                EnumKeys
            );
        }

        public static void RunTypeKeyLookup(TextLabel resultLabel)
        {
            RunBenchmark(
                resultLabel,
                "Type Key TryGetValue",
                TypeDictionary,
                TypeFrozenDictionary,
                TypeKeys
            );
        }

        public static void RunSizeComparison(TextLabel resultLabel)
        {
            // Build dictionaries of different sizes
            var sizes = new[] { 5, 15, 50 };
            string result = "[Size Comparison - String Key]\n";

            foreach (int size in sizes)
            {
                var dict = new Dictionary<string, int>();
                for (int i = 0; i < size; i++)
                    dict[$"key_{i}"] = i;

                var frozen = dict.ToFrozenDictionary();
                var keys = new string[] { $"key_0", $"key_{size / 2}", $"key_{size - 1}", "missing_key" };

                // Warmup
                for (int w = 0; w < WarmupIterations; w++)
                    foreach (var k in keys) { dict.TryGetValue(k, out _); frozen.TryGetValue(k, out _); }

                var sw = Stopwatch.StartNew();
                for (int i = 0; i < BenchmarkIterations; i++)
                    foreach (var k in keys)
                        dict.TryGetValue(k, out _);
                sw.Stop();
                long dictTime = sw.ElapsedMilliseconds;

                sw.Restart();
                for (int i = 0; i < BenchmarkIterations; i++)
                    foreach (var k in keys)
                        frozen.TryGetValue(k, out _);
                sw.Stop();
                long frozenTime = sw.ElapsedMilliseconds;

                double improvement = dictTime > 0 ? (1.0 - (double)frozenTime / dictTime) * 100.0 : 0;
                result += $"  Size={size}: Dict={dictTime}ms, Frozen={frozenTime}ms ({improvement:+0.0;-0.0}%)\n";
            }

            resultLabel.Text += result;
            Console.Write(result);
        }

        private static void RunBenchmark<TKey, TValue>(
            TextLabel resultLabel,
            string testName,
            Dictionary<TKey, TValue> dictionary,
            FrozenDictionary<TKey, TValue> frozenDictionary,
            TKey[] keys)
        {
            // Warmup
            for (int w = 0; w < WarmupIterations; w++)
                foreach (var k in keys) { dictionary.TryGetValue(k, out _); frozenDictionary.TryGetValue(k, out _); }

            // Dictionary benchmark
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < BenchmarkIterations; i++)
                foreach (var k in keys)
                    dictionary.TryGetValue(k, out _);
            sw.Stop();
            long dictTime = sw.ElapsedMilliseconds;

            // FrozenDictionary benchmark
            sw.Restart();
            for (int i = 0; i < BenchmarkIterations; i++)
                foreach (var k in keys)
                    frozenDictionary.TryGetValue(k, out _);
            sw.Stop();
            long frozenTime = sw.ElapsedMilliseconds;

            double improvement = dictTime > 0 ? (1.0 - (double)frozenTime / dictTime) * 100.0 : 0;
            string sign = improvement >= 0 ? "faster" : "slower";

            string line1 = $"[{testName}] ({BenchmarkIterations / 1000}K iters × {keys.Length} keys)\n";
            string line2 = $"  Dictionary:       {dictTime,6} ms\n";
            string line3 = $"  FrozenDictionary: {frozenTime,6} ms\n";
            string line4 = $"  Result: {Math.Abs(improvement):0.0}% {sign}\n";
            resultLabel.Text += line1 + line2 + line3 + line4;
            Console.Write(line1 + line2 + line3 + line4);
        }
    }
}
