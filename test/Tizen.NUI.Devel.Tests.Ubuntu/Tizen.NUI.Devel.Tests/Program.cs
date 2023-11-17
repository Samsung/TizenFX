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
using NUnitLite.TUnit;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework.TUnit;
using NUnit.Framework.Interfaces;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;
    public class App : Tizen.NUI.NUIApplication
    {
        static string tag = "NUITEST";

        public App() : base()
        {
            tlog.Debug(tag, "Call App()");
        }

        View root;
        public static TextLabel mainTitle;
        static string title = "NUI Auto TCT \n\n";
        float textSize = 30.0f;
        Window window;
        Layer layer;
        public static int mainPid;
        public static int mainTid;
        Timer timer;
        private EventThreadCallback eventThreadCallback;
        private EventThreadCallback.CallbackDelegate callbackDelegate;
        private NUnitLite.TUnit.TRunner trunner;
        private ManualResetEvent methodExecutionResetEvent;
        private TAsyncThreadMgr asyncThreadMgr;

        private bool testFinished = false;

        protected override void OnCreate()
        {
            base.OnCreate();

            tlog.Debug(tag, "OnCreate() START!");

            mainPid = Process.GetCurrentProcess().Id;
            mainTid = Thread.CurrentThread.ManagedThreadId;

            window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.Green;

            root = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.White,
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };

            layer = window.GetDefaultLayer();
            layer.Add(root);

            mainTitle = new TextLabel()
            {
                MultiLine = true,
                Text = title + $"Process ID: {Process.GetCurrentProcess().Id} \nThread ID: {Thread.CurrentThread.ManagedThreadId}\n",
                PixelSize = textSize,
                BackgroundColor = Color.Cyan,
                Size = new Size(window.WindowSize.Width * 0.9f, window.WindowSize.Height * 0.9f, 0),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            root.Add(mainTitle);

            Thread.CurrentThread.Name = "main";
            trunner = new NUnitLite.TUnit.TRunner();
            trunner.LoadTestsuite();

            asyncThreadMgr = TAsyncThreadMgr.GetInstance();
            methodExecutionResetEvent = asyncThreadMgr.GetMethodExecutionResetEvent();
            methodExecutionResetEvent.Reset();

            Task t = Task.Run(() =>
                {
                    Thread.CurrentThread.Name = "textRunner";
                    trunner._textRunner.Execute(trunner.args);
                    asyncThreadMgr.SetData(null, null, null, null, false);
                    methodExecutionResetEvent.Set();
                });

            callbackDelegate = new EventThreadCallback.CallbackDelegate(ProcessTest);
            eventThreadCallback = new EventThreadCallback(callbackDelegate);
            eventThreadCallback.Trigger();
        }

        private void ProcessTest()
        {
            methodExecutionResetEvent.WaitOne();

            if (eventThreadCallback == null || asyncThreadMgr.RunTestMethod() == false)
            {
                mainTitle.Text = title + "Finished!\nWill be terminated after 5 seconds";
                testFinished = true;

                timer = new Timer(300);
                timer.Tick += OnTick;
                timer.Start();
                return;
            }

            eventThreadCallback?.Trigger();
        }

        private bool OnTick(object obj, EventArgs e)
        {
            Thread.Sleep(5000);
            Exit();
            return false;
        }

        static public async Task MainTitleChangeBackgroundColor(Color color)
        {
            if (color != null)
            {
                mainTitle.BackgroundColor = color;
                await Task.Delay(900);
            }
        }

        static public async Task MainTitleChangeText(string tcTitle)
        {
            if (tcTitle != null)
            {
                var processId = Process.GetCurrentProcess().Id;
                var threadId = Thread.CurrentThread.ManagedThreadId;

                mainTitle.Text = $"{title}\nProcess ID: {processId}\nThread ID: {threadId}\n TC: {tcTitle}";
                await Task.Delay(20);

                tlog.Debug(tag, $"{title}\nProcess ID: {processId}\nThread ID: {threadId}\n TC: {tcTitle}");
            }
        }

        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
            tlog.Debug(tag, $"### OnAppControlReceived() START!");
        }

        protected override void OnResume()
        {
            tlog.Debug(tag, $"OnResume()");

            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnTerminate()
        {
            tlog.Debug(tag, "OnTerminate()");

            // Clear program
            timer?.Dispose();
            mainTitle?.Unparent();
            root?.Dispose();
            eventThreadCallback?.Dispose();

            // Stop test forcely.
            if (!testFinished)
            {
                // TODO : Currently, it is not works well...
                // trunner._textRunner.StopTest(true);
            }

            base.OnTerminate();
            Exit();
        }

        static void Main(string[] args)
        {
            tlog.Debug(tag, "NUI RUN!");
            App example = new App();
            example.Run(args);
        }
    };
}
