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

        /// <summary>
        /// Benchmark groups — each group has a title and its own set of benchmarks.
        /// </summary>
        private readonly List<(string GroupName, List<(string Name, Action<TextLabel> Run)> Items)> benchmarkGroups = new()
        {
            ("FrozenDictionary", new List<(string, Action<TextLabel>)>
            {
                ("String Key Lookup", FrozenDictionaryBenchmark.RunStringKeyLookup),
                ("Enum Key Lookup", FrozenDictionaryBenchmark.RunEnumKeyLookup),
                ("Type Key Lookup", FrozenDictionaryBenchmark.RunTypeKeyLookup),
                ("Size Comparison", FrozenDictionaryBenchmark.RunSizeComparison),
            }),

            ("Stackalloc / Fixed", new List<(string, Action<TextLabel>)>
            {
                ("Single Struct (Old)", StackallocBenchmark.RunSingleStructOldUI),
                ("Single Struct (New)", StackallocBenchmark.RunSingleStructNewUI),
                ("Struct Array (Old)", StackallocBenchmark.RunStructArrayOldUI),
                ("Struct Array (New)", StackallocBenchmark.RunStructArrayNewUI),
            }),

            ("Sealed Class", new List<(string, Action<TextLabel>)>
            {
                ("Virtual (sealed)", SealedClassBenchmark.RunVirtualSealedUI),
                ("Virtual (non-sealed)", SealedClassBenchmark.RunVirtualNonSealedUI),
                ("Interface (sealed)", SealedClassBenchmark.RunInterfaceSealedUI),
                ("Interface (non-sealed)", SealedClassBenchmark.RunInterfaceNonSealedUI),
            }),

            // Add more benchmark groups here in the future
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
                    CellPadding = new Size2D(0, 6),
                },
            };
            rootView.Add(scrollView);

            // Create grouped benchmark sections
            foreach (var (groupName, items) in benchmarkGroups)
            {
                AddGroupSection(groupName, items);
            }

            // Global "Run All" button
            var runAllButton = new Button()
            {
                Text = "▶▶ Run All Benchmarks",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                Padding = new Extents(10, 10, 10, 10),
                PointSize = 16,
                BackgroundColor = new Color(0.6f, 0.2f, 0.5f, 1.0f),
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

        private void AddGroupSection(string groupName, List<(string Name, Action<TextLabel> Run)> items)
        {
            // Group header
            var header = new TextLabel()
            {
                Text = $"━━ {groupName} ━━",
                TextColor = new Color(0.6f, 0.75f, 0.95f, 1.0f),
                PointSize = 15,
                HorizontalAlignment = HorizontalAlignment.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                FontFamily = "SamsungOneUI",
                Padding = new Extents(0, 0, 8, 2),
            };
            scrollView.Add(header);

            // Individual benchmark buttons
            foreach (var (name, run) in items)
            {
                var button = CreateBenchmarkButton($"{groupName}: {name}", run);
                scrollView.Add(button);
            }

            // Per-group "Run All" button
            var runGroupButton = new Button()
            {
                Text = $"▶ Run All {groupName}",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                Padding = new Extents(10, 10, 8, 8),
                PointSize = 14,
                BackgroundColor = new Color(0.2f, 0.6f, 0.3f, 1.0f),
                TextColor = Color.White,
                CornerRadius = 10,
            };
            runGroupButton.Clicked += (s, e) => RunGroupBenchmarks(groupName, items);
            scrollView.Add(runGroupButton);
        }

        private Button CreateBenchmarkButton(string name, Action<TextLabel> runBenchmark)
        {
            var button = new Button()
            {
                Text = name,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                Padding = new Extents(10, 10, 8, 8),
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

        private void RunGroupBenchmarks(string groupName, List<(string Name, Action<TextLabel> Run)> items)
        {
            resultLabel.Text = $"Running {groupName} benchmarks...\n\n";
            Console.WriteLine($"\nRunning {groupName} benchmarks...\n");
            int index = 0;

            Timer timer = new Timer(200);
            timer.Tick += (s, e) =>
            {
                if (index < items.Count)
                {
                    var (name, run) = items[index];
                    resultLabel.Text += $"--- {name} ---\n";
                    Console.WriteLine($"--- {name} ---");
                    run(resultLabel);
                    resultLabel.Text += "\n";
                    Console.WriteLine();
                    index++;
                    return true;
                }
                resultLabel.Text += $"=== {groupName} complete ===\n";
                Console.WriteLine($"=== {groupName} complete ===");
                return false;
            };
            timer.Start();
        }

        private void RunAllBenchmarks()
        {
            resultLabel.Text = "Running all benchmarks...\n\n";
            Console.WriteLine("\nRunning all benchmarks...\n");

            // Flatten all groups into a single queue
            var allBenchmarks = new List<(string GroupName, string Name, Action<TextLabel> Run)>();
            foreach (var (groupName, items) in benchmarkGroups)
            {
                foreach (var (name, run) in items)
                {
                    allBenchmarks.Add((groupName, name, run));
                }
            }

            int index = 0;
            string currentGroup = "";

            Timer timer = new Timer(200);
            timer.Tick += (s, e) =>
            {
                if (index < allBenchmarks.Count)
                {
                    var (groupName, name, run) = allBenchmarks[index];
                    if (groupName != currentGroup)
                    {
                        resultLabel.Text += $"━━ {groupName} ━━\n";
                        Console.WriteLine($"━━ {groupName} ━━");
                        currentGroup = groupName;
                    }
                    resultLabel.Text += $"--- {name} ---\n";
                    Console.WriteLine($"--- {name} ---");
                    run(resultLabel);
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

