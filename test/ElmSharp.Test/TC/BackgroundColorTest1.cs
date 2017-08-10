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

namespace ElmSharp.Test
{
    class BackgroundColorTest1 : TestCaseBase
    {
        public override string TestName => "BackgroundColorTest1";
        public override string TestDescription => "To test basic operation of Widget's background Color";

        

        public override void Run(Window window)
        {
            Button button1 = new Button(window) {
                Text = "Target Button",
            };
            button1.Resize(window.ScreenSize.Width, 100);
            button1.Move(0, 0);
            button1.Show();

            Label label1 = new Label(window) {
                Text = button1.BackgroundColor.ToString(),
                BackgroundColor = Color.Black,
                Color = Color.White
            };
            label1.Resize(window.ScreenSize.Width, 100);
            label1.Move(0, 100);
            label1.Show();

            Button button2 = new Button(window) {
                Text = "Set Color.Red",
                BackgroundColor = Color.Red,
            };
            button2.Clicked += (e, o) =>
            {
                button1.BackgroundColor = Color.Red;
                label1.Text = button1.BackgroundColor.ToString();
            };
            button2.Resize(window.ScreenSize.Width, 100);
            button2.Move(0, 400);
            button2.Show();

            Button button3 = new Button(window) {
                Text = "Set Color(125,200,255, 150)",
                BackgroundColor = new Color(125,200,255, 150)
            };
            button3.Clicked += (e, o) =>
            {
                button1.BackgroundColor = button3.BackgroundColor;
                label1.Text = button1.BackgroundColor.ToString();
            };
            button3.Resize(window.ScreenSize.Width, 100);
            button3.Move(0, 500);
            button3.Show();

            Button button4 = new Button(window) {
                Text = "Set Color(125, 200, 255, 10)",
                BackgroundColor = new Color(125, 200, 255, 10)
            };
            button4.Clicked += (e,o) =>
            {
                button1.BackgroundColor = button4.BackgroundColor;
                label1.Text = button1.BackgroundColor.ToString();
            };
            button4.Resize(window.ScreenSize.Width, 100);
            button4.Move(0, 600);
            button4.Show();

            Button button5 = new Button(window) {
                Text = "Set Color.Default",
                BackgroundColor = Color.Default
            };
            button5.Clicked += (e, o) =>
            {
                button1.BackgroundColor = button5.BackgroundColor;
                label1.Text = button1.BackgroundColor.ToString();
            };
            button5.Resize(window.ScreenSize.Width, 100);
            button5.Move(0, 700);
            button5.Show();
        }

    }
}
