/*
 *  Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Reflection;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;
using NUnitLite.TUnit;
using NUnit.Framework.TUnit;
using NUnit.Framework.Interfaces;

namespace Tizen.NUI.Devel.Manual.Tests
{
    using tlog = Tizen.Log;

    public class App : Tizen.NUI.NUIApplication
    {
        private static string tag = "NUITEST";

        public App() : base()
        {
            tlog.Debug(tag, "Call App()");
        }

        private Window window;
        private Navigator navigator;
        private ContentPage rootPage;
        private ManualTest manualTest = ManualTest.GetInstance();
        private TRunner tRunner;
        private const string STEP_ATTRIBUTE_NAME = "NUnit.Framework.StepAttribute";
        private const string PRECONDITION_ATTRIBUTE_NAME = "NUnit.Framework.PreconditionAttribute";
        private const string POSTCONDITION_ATTRIBUTE_NAME = "NUnit.Framework.PostconditionAttribute";

        private ManualTestList GetTests()
        {
            if (tRunner == null || manualTest == null) return null;
            int idx = 0;

            var tests = ManualTest.TestList;

            foreach (KeyValuePair<string, ITest> pair in tRunner.GetTestList())
            {

                IEnumerator<CustomAttributeData> customAttributes = pair.Value.Method.MethodInfo.CustomAttributes.GetEnumerator();
                List<string> preconditions = new List<string>();
                preconditions.Add("Pre-Conditions:");
                List<string> steps = new List<string>();
                steps.Add("Steps:");
                List<string> postconditions = new List<string>();
                postconditions.Add("Post-Conditions:");

                while (customAttributes.MoveNext())
                {
                    if (customAttributes.Current.AttributeType.FullName.Equals(STEP_ATTRIBUTE_NAME))
                    {
                        steps.Add(customAttributes.Current.ConstructorArguments[0].Value + "." + customAttributes.Current.ConstructorArguments[1].Value);
                    }
                    else if (customAttributes.Current.AttributeType.FullName.Equals(PRECONDITION_ATTRIBUTE_NAME))
                    {
                        preconditions.Add(customAttributes.Current.ConstructorArguments[0].Value + "." + customAttributes.Current.ConstructorArguments[1].Value);
                    }
                    else if (customAttributes.Current.AttributeType.FullName.Equals(POSTCONDITION_ATTRIBUTE_NAME))
                    {
                        postconditions.Add(customAttributes.Current.ConstructorArguments[0].Value + "." + customAttributes.Current.ConstructorArguments[1].Value);
                    }
                }

                tests.Add(new ManualTestItem(idx, pair.Key)
                {
                    PreConditions = preconditions,
                    Steps = steps,
                    PostConditions = postconditions,
                });

                idx++;
            }

            return tests;


            /*
            var tests = new ManualTestList();
            Assembly assembly = this.GetType().Assembly;
            Type exampleType = assembly.GetType("Tizen.NUI.Devel.Tests.Manual.ManualTestPage");

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"type.Name={type.Name}, type.FullName={type.FullName}");
                if (exampleType.IsAssignableFrom(type) && type.IsClass && type.Name != "ManualTestPage")
                {
                    tests.Add(new ManualTestItem(type.Name, type.FullName));
                }
            }

            return tests;
            */
        }

        private void RunTest(ManualTestItem item)
        {
            manualTest.CurrentTest = item;
            tRunner.Execute();
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            tlog.Debug(tag, "OnCreate() START!");

            tRunner = new TRunner();
            tRunner.LoadTestsuite();
             //tRunner.SingleTestDone += OnSingleTestDone;

            var testList = GetTests();

            window = NUIApplication.GetDefaultWindow();
            navigator = window.GetDefaultNavigator();
            navigator.Popped += (object obj, PoppedEventArgs ev) =>
            {
                Page top = navigator.Peek();
                if (top is ManualTestPage testPage)
                {
                    manualTest.CurrentPage = null;
                    manualTest.CurrentTest = null;
                }
            };
            var testBar = new AppBar()
            {
                BindingContext = testList,
                AutoNavigationContent = false,
            };
            testBar.SetBinding(AppBar.TitleProperty, "Title");

            var testListView = new CollectionView()
            {
                ItemsSource = testList,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    RecyclerViewItem item = new RecyclerViewItem()
                    {
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                        HeightSpecification = 75,
                        Layout = new LinearLayout()
                        {
                            LinearOrientation = LinearLayout.Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            CellPadding = new Size2D(10, 20),
                        },
                        BorderlineColor = Color.LightGrey,
                        BorderlineWidth = 2.0f,
                        BorderlineOffset = -1f,
                        BackgroundColor = new Color(1f, 1f, 1f, 1f),
                        Padding = new Extents(30, 30, 0, 0),
                    };
                    var Label = new TextLabel()
                    {
                        PointSize = 20,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                    };
                    Label.SetBinding(TextLabel.TextProperty, "TestCaseName");
                    item.Add(Label);

                    var SubLabel = new TextLabel()
                    {
                        PointSize = 20,
                        HorizontalAlignment = HorizontalAlignment.End,
                    };
                    SubLabel.SetBinding(TextLabel.TextProperty, "TestStateName");
                    SubLabel.SetBinding(TextLabel.TextColorProperty, "TestStateColor");
                    item.Add(SubLabel);

                    return item;
                }),
                Header = new DefaultTitleItem()
                {
                    Text = "TestCase",
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                },
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                SelectionMode = ItemSelectionMode.SingleAlways,
            };
            testListView.SelectionChanged +=  (object sender, SelectionChangedEventArgs ev) =>
            {
                tlog.Debug(tag, $"OnSelectionChanged() {ev.CurrentSelection}");

                if (ev.CurrentSelection.Count == 0) return;

                if (ev.CurrentSelection[0] is ManualTestItem selItem)
                {
                    tlog.Debug(tag, $"selItem.TestIndex={selItem.TestIndex}, selItem.TestCaseName={selItem.TestCaseName}");
                    if (selItem != null)
                    {
                        RunTest(selItem);
                    }
                }
                testListView.SelectedItem = null;
            };

            rootPage = new ContentPage()
            {
                AppBar = testBar,
                Content = testListView,
            };

            navigator.Push(rootPage);
        }

        protected override void OnResume()
        {
            base.OnResume();

            tlog.Debug(tag, $"OnResume()");
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        static void Main(string[] args)
        {
            tlog.Debug(tag, "NUI RUN!");
            App test = new App();
            test.Run(args);
        }
    };
}
