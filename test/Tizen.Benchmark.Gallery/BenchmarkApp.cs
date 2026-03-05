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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.Benchmark.Gallery
{
    class BenchmarkApp : NUIApplication
    {
        private Window window;
        private View rootView;
        private ScrollableBase scrollView;
        private TextLabel resultLabel;

        private readonly List<(string Name, Action<TextLabel> RunBenchmark)> benchmarks = new List<(string, Action<TextLabel>)>
        {
            ("FrozenDictionary: String Key Lookup", FrozenDictionaryBenchmark.RunStringKeyLookup),
            ("FrozenDictionary: Enum Key Lookup", FrozenDictionaryBenchmark.RunEnumKeyLookup),
            ("FrozenDictionary: Type Key Lookup", FrozenDictionaryBenchmark.RunTypeKeyLookup),
            ("FrozenDictionary: Size Comparison", FrozenDictionaryBenchmark.RunSizeComparison),
            // Add more benchmarks here in the future
        };

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            window = GetDefaultWindow();
            window.BackgroundColor = new Color(0.1f, 0.1f, 0.12f, 1.0f);

            rootView = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(20, 20, 20, 20),
                    CellPadding = new Size2D(0, 10),
                },
            };
            window.Add(rootView);

            // Title
            var titleLabel = new TextLabel()
            {
                Text = "TizenFX Performance Benchmark",
                TextColor = new Color(0.9f, 0.9f, 0.95f, 1.0f),
                PointSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                Padding = new Extents(0, 0, 10, 20),
                FontFamily = "SamsungOneUI",
            };
            rootView.Add(titleLabel);

            // Scrollable button area
            scrollView = new ScrollableBase()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                Weight = 0.55f,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 8),
                },
            };
            rootView.Add(scrollView);

            // Create benchmark buttons
            foreach (var (name, runBenchmark) in benchmarks)
            {
                var button = CreateBenchmarkButton(name, runBenchmark);
                scrollView.Add(button);
            }

            // "Run All" button
            var runAllButton = new Button()
            {
                Text = "▶ Run All Benchmarks",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                Padding = new Extents(10, 10, 10, 10),
                PointSize = 16,
                BackgroundColor = new Color(0.2f, 0.6f, 0.3f, 1.0f),
                TextColor = Color.White,
                CornerRadius = 12,
            };
            runAllButton.Clicked += (s, e) => RunAllBenchmarks();
            rootView.Add(runAllButton);

            // Result area
            var resultScrollView = new ScrollableBase()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                Weight = 0.45f,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                BackgroundColor = new Color(0.15f, 0.15f, 0.18f, 1.0f),
                CornerRadius = 12,
                Padding = new Extents(15, 15, 15, 15),
            };
            rootView.Add(resultScrollView);

            resultLabel = new TextLabel()
            {
                Text = "Tap a button to run a benchmark.\nResults will appear here.",
                TextColor = new Color(0.7f, 0.8f, 0.7f, 1.0f),
                PointSize = 13,
                MultiLine = true,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                FontFamily = "SamsungOneUI",
            };
            resultScrollView.Add(resultLabel);
        }

        private Button CreateBenchmarkButton(string name, Action<TextLabel> runBenchmark)
        {
            var button = new Button()
            {
                Text = name,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                Padding = new Extents(10, 10, 10, 10),
                PointSize = 14,
                BackgroundColor = new Color(0.2f, 0.35f, 0.55f, 1.0f),
                TextColor = Color.White,
                CornerRadius = 10,
            };
            button.Clicked += (s, e) =>
            {
                resultLabel.Text = $"Running: {name}...\n";
                Timer timer = new Timer(100);
                timer.Tick += (t, ev) =>
                {
                    runBenchmark(resultLabel);
                    return false;
                };
                timer.Start();
            };
            return button;
        }

        private void RunAllBenchmarks()
        {
            resultLabel.Text = "Running all benchmarks...\n\n";
            Console.WriteLine("\nRunning all benchmarks...\n");
            int index = 0;

            Timer timer = new Timer(200);
            timer.Tick += (s, e) =>
            {
                if (index < benchmarks.Count)
                {
                    var (name, runBenchmark) = benchmarks[index];
                    resultLabel.Text += $"--- {name} ---\n";
                    Console.WriteLine($"--- {name} ---");
                    runBenchmark(resultLabel);
                    resultLabel.Text += "\n";
                    Console.WriteLine();
                    index++;
                    return true;
                }
                resultLabel.Text += "=== All benchmarks complete ===\n";
                Console.WriteLine("=== All benchmarks complete ===");
                return false;
            };
            timer.Start();
        }

        static void Main(string[] args)
        {
            var app = new BenchmarkApp();
            app.Run(args);
        }
    }
}
