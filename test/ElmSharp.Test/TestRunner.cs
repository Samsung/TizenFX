// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class TestRunner
    {
        public TestRunner()
        {
        }

        public void Run(string[] args)
        {
            Elementary.Initialize();

            EcoreSynchronizationContext.Initialize();

            Window window = new Window("TestWindow");
            window.Show();
            window.KeyGrab(EvasKeyEventArgs.PlatformBackButtonName, false);
            window.KeyUp += (s, e) =>
            {
                if (e.KeyName == EvasKeyEventArgs.PlatformBackButtonName)
                {
                    EcoreMainloop.Quit();
                }
            };

            var testCases = GetTestCases();
            TestCaseBase theTest = null;

            if (args.Count() > 0)
            {
                theTest = testCases.Where((testCase) => testCase.TestName == args[0] || testCase.GetType().ToString() == args[0]).FirstOrDefault();
            }

            if (theTest != null)
            {
                theTest.Run(window);
                EcoreMainloop.Begin();
            } else
            {
                foreach (var test in testCases)
                {
                    Console.WriteLine("{0}", test.TestName);
                }
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

        static void Main(string[] args)
        {
            TestRunner testRunner = new TestRunner();
            testRunner.Run(args);
        }
    }
}
