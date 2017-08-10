using Tizen.Applications;
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
using ElmSharp;
using System.Diagnostics;

namespace ElmSharp.Test
{
    class WindowInternalTest : TestCaseBase
    {
        public override string TestName => "WindowInternalTest";
        public override string TestDescription => "Window Test";

        public override void Run(Window window)
        {
            var firstWindow = (Application.Current as TestRunner)?._firstPageWindow;
            firstWindow.Hide();
            firstWindow.Unrealize();

            Button button1 = new Button(window) {
                Text = "Iconified",
            };
            button1.Resize(window.ScreenSize.Width, 100);
            button1.Move(0, 0);
            button1.Show();

            button1.Clicked += (e, o) =>
            {
                window.Iconified = true;
            };

            Button button2 = new Button(window)
            {
                Text = "WinKeyGrab",
            };
            button2.Resize(window.ScreenSize.Width, 100);
            button2.Move(0, 100);
            button2.Show();

            button2.Clicked += (e, o) =>
            {
                Debug.WriteLine("@@KeyGrab");
                window.KeyGrab(EvasKeyEventArgs.PlatformHomeButtonName, true);
                window.WinKeyGrab(EvasKeyEventArgs.PlatformHomeButtonName, KeyGrabMode.Exclusive);
            };

            Button button3 = new Button(window)
            {
                Text = "WinUnKeyGrab",
            };
            button3.Resize(window.ScreenSize.Width, 100);
            button3.Move(0, 200);
            button3.Show();

            button3.Clicked += (e, o) =>
            {
                Debug.WriteLine("@@UnKeyGrab");
                window.WinKeyUngrab(EvasKeyEventArgs.PlatformHomeButtonName);
                window.KeyUngrab(EvasKeyEventArgs.PlatformHomeButtonName);

            };
            window.KeyGrab(EvasKeyEventArgs.PlatformBackButtonName, true);
            EventHandler<EvasKeyEventArgs> handler = (s, e) =>
            {
                Debug.WriteLine("@@KeyDown start" + e.KeyName);

                if (e.KeyName == EvasKeyEventArgs.PlatformBackButtonName)
                {
                    Application.Current.Exit();
                }
                if (e.KeyName == EvasKeyEventArgs.PlatformHomeButtonName)
                {
                    Debug.WriteLine("@@KeyDown OK : " + window.Iconified);
                    window.Iconified = !window.Iconified;
                }
            };

            window.KeyUp += handler;
        }

    }
}
