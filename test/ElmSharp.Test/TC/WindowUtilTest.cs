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
using System.IO;
using ElmSharp;
using System.Diagnostics;

namespace ElmSharp.Test
{
    class WindowUtilTest : TestCaseBase
    {
        public override string TestName => "WindowUtilTest";
        public override string TestDescription => "Window Util Test";

        void DeleteWin(Window window)
        {
            window.Hide();
            window.Unrealize();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        Window CreateWin(Window parent, WindowType type, bool whiteBg)
        {
            Window win = new Window(parent, "testwin", type);
            win.Show();

            win.BackButtonPressed += (s, e) =>
            {
                DeleteWin(win);
            };

            if (whiteBg)
            {
                Conformant conformant = new Conformant(win);
                conformant.Show();
                Box box = new Box(win)
                {
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                };
                box.Show();
                var bg = new Background(win);
                bg.Color = Color.White;
                bg.SetContent(box);
                conformant.SetContent(bg);
            }

            Button button = new Button(win)
            {
                Text = "Delete Window",                
            };
            button.Resize(win.ScreenSize.Width, 100);
            button.Move(0, win.ScreenSize.Height - 105);
            button.SetPartColor("bg", Color.Red);
            button.Show();

            button.Clicked += (e, o) =>
            {
                DeleteWin(win);
            };

            return win;
        }

        public override void Run(Window window)
        {
            int buttonW = window.ScreenSize.Width / 2 - 10;
            int buttonH = 110;

            Button button1 = new Button(window)
            {
                Text = "Brightness</br>30",
            };
            button1.Resize(buttonW, buttonH);
            button1.Move(5, 5);
            button1.Show();

            button1.Clicked += (e, o) =>
            {
                window.Brightness = 30;
            };

            Button button2 = new Button(window)
            {
                Text = "Brightness</br>Default",
            };
            button2.Resize(buttonW, buttonH);
            button2.Move(buttonW + 15, 5);
            button2.Show();

            button2.Clicked += (e, o) =>
            {
                window.Brightness = -1;
            };

            Button button3 = new Button(window)
            {
                Text = "ScreenMode</br>AlwaysOn",
            };
            button3.Resize(buttonW, buttonH);
            button3.Move(5, buttonH + 15);
            button3.Show();

            button3.Clicked += (e, o) =>
            {
                window.ScreenMode = ScreenMode.AlwaysOn;
            };

            Button button4 = new Button(window)
            {
                Text = "ScreenMode</br>Default",
            };
            button4.Resize(buttonW, buttonH);
            button4.Move(buttonW + 15, buttonH + 15);
            button4.Show();

            button4.Clicked += (e, o) =>
            {
                window.ScreenMode = ScreenMode.Default;
            };

            Button button5 = new Button(window)
            {
                Text = "Window Notification Level</br>Top",
            };
            button5.Resize(window.ScreenSize.Width - 10, buttonH);
            button5.Move(5, (buttonH +10)* 2 + 5);
            button5.Show();

            button5.Clicked += (e, o) =>
            {
                Window win = CreateWin(window, WindowType.Notification, true);

                Console.WriteLine("Notifiaction Level : {0}", win.NotificationLevel);
                win.NotificationLevel = NotificationLevel.Top;
                Console.WriteLine("Notifiaction Level : {0}", win.NotificationLevel);

                Label label = new Label(win)
                {
                    Text = string.Format("This Notification Window Level : {0}", win.NotificationLevel),
                    Color = Color.White,
                };
                label.Resize(window.ScreenSize.Width, 100);
                label.Move(0, 100);
                label.Show();
            };
        }
    }
}
