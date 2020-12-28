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
    class ButtonTest1 : TestCaseBase
    {
        public override string TestName => "ButtonTest1";
        public override string TestDescription => "To test basic operation of Button";

        void SetButtonEventHandler(Button button)
        {
            button.Clicked += (s, e) =>
            {
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.BackgroundColor);
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName);
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName.ToLower());
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName.ToLower().Replace("elm_", ""));
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName.ToLower().Replace("elm_", "") + "/" + "bg");
            };

            button.Pressed += (s, e) =>
            {
                Console.WriteLine("{0} Pressed!", button.Text);
            };

            button.Released += (s, e) =>
            {
                Console.WriteLine("{0} Released!", button.Text);
            };

            button.Repeated += (s, e) =>
            {
                Console.WriteLine("{0} Repeated!", button.Text);
            };

            button.Show();
        }

        public override void Run(Window window)
        {
            Button button1 = new Button(window) {
                Text = "Button 1",
            };
            button1.SetPartColor("bg", Color.Red);
            SetButtonEventHandler(button1);
            button1.Resize(500, 100);
            button1.Move(0, 0);

            Button button2 = new Button(window) {
                Text = "Button 2",
                BackgroundColor = Color.Red,
            };
            SetButtonEventHandler(button2);
            button2.Resize(500, 100);
            button2.Move(0, 200);

            Button button3 = new Button(window) {
                Text = "Button 3",
                BackgroundColor = new Color(125,200,255, 150)
            };
            SetButtonEventHandler(button3);
            button3.Resize(500, 100);
            button3.Move(0, 400);

            Button button4 = new Button(window) {
                Text = "Button 4",
                BackgroundColor = new Color(125, 200, 255, 10)
            };
            SetButtonEventHandler(button4);
            button4.Resize(500, 100);
            button4.Move(0, 600);
        }
    }
}
