/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Tizen.Applications;

namespace ElmSharp.Test
{
    public class TestRunner : CoreUIApplication
    {
        private Window _firstPageWindow;
        private static bool s_terminated;

        public static string ResourceDir { get; private set; }

        public TestRunner()
        {
            s_terminated = false;
        }

        protected override void OnCreate()
        {
            ResourceDir = DirectoryInfo.Resource;

            var testCases = GetTestCases();
            CreateFirstPage(testCases);
            base.OnCreate();
        }

        protected override void OnTerminate()
        {
            s_terminated = true;
            base.OnTerminate();
        }

        public void RunStandalone(string[] args)
        {
            ResourceDir = Path.Combine(Path.GetDirectoryName(typeof(TestRunner).GetTypeInfo().Assembly.Location), "res");

            EcoreSynchronizationContext.Initialize();

            var testCases = GetTestCases();
            TestCaseBase theTest = null;

            if (args.Count() > 0)
            {
                theTest = testCases.Where((testCase) => testCase.TestName == args[0] || testCase.GetType().ToString() == args[0]).FirstOrDefault();
            }

            if (theTest != null)
            {
                StartTC(theTest);
                EcoreMainloop.Begin();
            }
            else
            {
                CreateFirstPage(testCases);
                EcoreMainloop.Begin();
            }

            Elementary.Shutdown();
        }

        private IEnumerable<TestCaseBase> GetTestCases()
        {
            Assembly asm = typeof(TestRunner).GetTypeInfo().Assembly;
            Type testCaseType = typeof(TestCaseBase);

            var tests = from test in asm.GetTypes()
                        where testCaseType.IsAssignableFrom(test) && !test.GetTypeInfo().IsInterface && !test.GetTypeInfo().IsAbstract
                        select Activator.CreateInstance(test) as TestCaseBase;

            return from test in tests
                   orderby test.TestName
                   select test;
        }

        internal static void UIExit()
        {
            EcoreMainloop.Quit();
        }

        private Window CreateWindow(bool isSecond = false)
        {
            Window window = new Window("ElmSharp UI Tests");
            window.Show();
            if (isSecond)
            {
                window.KeyGrab(EvasKeyEventArgs.PlatformBackButtonName, true);
                window.KeyUp += (s, e) =>
                {
                    if (e.KeyName == EvasKeyEventArgs.PlatformBackButtonName)
                    {
                        window.Hide();
                        window.Unrealize();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                };
            }
            else
            {
                window.KeyGrab(EvasKeyEventArgs.PlatformBackButtonName, false);
                window.KeyUp += (s, e) =>
                {
                    if (e.KeyName == EvasKeyEventArgs.PlatformBackButtonName)
                    {
                        UIExit();
                    }
                };
            }
            return window;
        }

        private void CreateFirstPage(IEnumerable<TestCaseBase> testCases)
        {
            _firstPageWindow = CreateWindow();
            Console.WriteLine("Screen DPI : {0}", _firstPageWindow.ScreenDpi.X);
            Conformant conformant = new Conformant(_firstPageWindow);
            conformant.Show();
            Box box = new Box(_firstPageWindow)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();
            conformant.SetContent(box);

            GenList list = new GenList(_firstPageWindow)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (data, part) =>
                {
                    return string.Format("{0}",(string)data);
                }
            };

            foreach (var tc in testCases)
            {
                list.Append(defaultClass, tc.TestName);
            }

            list.ItemSelected += (s, e) =>
            {
                foreach (var tc in testCases)
                {
                    if (tc.TestName == (string)(e.Item.Data))
                    {
                        StartTCFromList(tc);
                        break;
                    }
                }
            };
            list.Show();

            box.PackEnd(list);
        }

        private void StartTC(TestCaseBase tc)
        {
            Window window = CreateWindow();
            tc.Run(window);
        }

        private void StartTCFromList(TestCaseBase tc)
        {
            Window window = CreateWindow(true);
            tc.Run(window);
        }

        static void Main(string[] args)
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();

            Console.WriteLine("ELM_PROFILE : {0}", Elementary.GetProfile());

            TestRunner testRunner = new TestRunner();
            testRunner.Run(args);

            // if running with appfw is failed, below line will be executed.
            if (!s_terminated)
            {
                testRunner.RunStandalone(args);
            }
        }
    }
}
