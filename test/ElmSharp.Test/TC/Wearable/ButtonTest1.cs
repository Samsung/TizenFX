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
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.Wearable
{
    class ButtonTest1 : WearableTestCase
    {
        public override string TestName => "ButtonTest1";
        public override string TestDescription => "To test basic operation of Button";

        void SetButtonEventHandler(Button button)
        {
            button.Clicked += (s, e) =>
            {
                Log.Debug($"{button.Text} Clicked! : {button.BackgroundColor}");
            };

            button.Pressed += (s, e) =>
            {
                Log.Debug("{button.Text} Pressed!");
            };

            button.Released += (s, e) =>
            {
                Log.Debug("{button.Text} Released!");
            };

            button.Repeated += (s, e) =>
            {
                Log.Debug("{button.Text} Repeated!");
            };

            button.Show();
        }

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();
            Log.Debug(square.ToString());

            Button button1 = new Button(window)
            {
                Text = "Button 1",
            };
            button1.SetPartColor("bg", Color.Red);
            SetButtonEventHandler(button1);
            button1.Resize(square.Width, square.Height/4);
            button1.Move(square.X, square.Y);

            Button button2 = new Button(window)
            {
                Text = "Button 2",
                BackgroundColor = Color.Red,
            };
            SetButtonEventHandler(button2);
            button2.Resize(square.Width, square.Height / 4);
            button2.Move(square.X, square.Y + square.Height / 4);

            Button button3 = new Button(window)
            {
                Text = "Button 3",
                BackgroundColor = new Color(125, 200, 255, 150)
            };
            SetButtonEventHandler(button3);
            button3.Resize(square.Width, square.Height / 4);
            button3.Move(square.X, square.Y + square.Height / 2);

            Button button4 = new Button(window)
            {
                Text = "Button 4",
                BackgroundColor = new Color(125, 200, 255, 10)
            };
            SetButtonEventHandler(button4);
            button4.Resize(square.Width, square.Height / 4);
            button4.Move(square.X, square.Y + square.Height * 3 / 4);
        }
    }
}
