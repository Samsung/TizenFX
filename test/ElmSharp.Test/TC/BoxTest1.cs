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
    class BoxTest1 : TestCaseBase
    {
        public override string TestName => "BoxTest1";
        public override string TestDescription => "To test basic operation of Box";

        Box box;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            box = new Box(window);
            box.BackgroundColor = Color.Orange;
            conformant.SetContent(box);
            box.Show();

            Button button1 = new Button(window) {
                Text = "Button 1",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                AutomationId = "button1"
            };
            Button button2 = new Button(window) {
                Text = "Button 2",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = new Color(50,100,200,75),
                AutomationId = "button2"
            };
            Button button3 = new Button(window) {
                Text = "Button 3",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = Color.Olive,
                AutomationId = "button3"
            };

            box.PackEnd(button1);
            box.PackEnd(button2);
            box.PackEnd(button3);

            button1.Show();
            button2.Show();
            button3.Show();

            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button1_Clicked;
            button3.Clicked += Button1_Clicked;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("{0} Clicked! - Button's BG Color : {1}, Box's BG Color : {2}", ((Button)sender).Text, ((Button)sender).BackgroundColor, box.BackgroundColor);
        }
    }
}
