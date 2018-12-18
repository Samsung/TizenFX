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
    class TooltipTest1 : TestCaseBase
    {
        public override string TestName => "TooltipTest1";
        public override string TestDescription => "To test basic operation of Tooltip";

        void SetButtonEventHandler(Button button)
        {
            button.Clicked += (s, e) =>
            {
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.BackgroundColor);
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName);
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName.ToLower());
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName.ToLower().Replace("elm_", ""));
                Console.WriteLine("{0} Clicked! : {1}", button.Text, button.ClassName.ToLower().Replace("elm_", "") + "/" + "bg");

                Console.WriteLine("Tooltip's Orientation {0}", button.TooltipOrientation);
                Console.WriteLine("Tooltip's Window mode {0}", button.TooltipWindowMode);
                Console.WriteLine("Tooltip's Style {0}", button.TooltipStyle);
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
                Text = "Basic operation of Tooltip",
            };
            button1.SetPartColor("bg", Color.Red);
            button1.Resize(600, 100);
            button1.Move(0, 0);
            button1.SetTooltipText("Tooltip Tes1");
            SetButtonEventHandler(button1);

            Button button2 = new Button(window) {
                Text = "Orientation of Tooltip",
                BackgroundColor = Color.Pink,
            };
            button2.Resize(600, 100);
            button2.Move(0, 200);
            button2.SetTooltipText("Tooltip Test2");
            button2.TooltipOrientation = TooltipOrientation.Bottom;
            button2.Text = button2.TooltipOrientation.ToString();
            SetButtonEventHandler(button2);

            Button button3 = new Button(window) {
                Text = "Style of Tooltip",
                BackgroundColor = Color.Purple
            };
            button3.SetTooltipText("Tooltip Test3");
            button3.TooltipStyle = "transparent";
            button3.Text = button3.TooltipStyle;
            button3.Resize(600, 100);
            button3.Move(0, 400);
            SetButtonEventHandler(button3);

            Button button4 = new Button(window) {
                Text = "Window mode of Tooltip",
                BackgroundColor = Color.Green
            };
            button4.SetTooltipText("Tooltip Test4");
            button4.TooltipWindowMode = true;
            button4.Text = button4.TooltipWindowMode.ToString();
            button4.Resize(600, 100);
            button4.Move(0, 600);
            SetButtonEventHandler(button4);
        }

    }
}
