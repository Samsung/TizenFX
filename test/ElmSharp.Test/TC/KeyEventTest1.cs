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
    class KeyEventTest1 : TestCaseBase
    {
        public override string TestName => "KeyEventTest1";
        public override string TestDescription => "To test basic operation of KeyEvent";

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
                WeightY = 1
            };
            Button button2 = new Button(window) {
                Text = "Button 2",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = new Color(50,100,200,75)
            };

            Box innerBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            innerBox.Show();
            Button button3 = new Button(window)
            {
                Text = "Button 3",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = new Color(50, 100, 200, 75)
            };

            box.PackEnd(button1);
            box.PackEnd(button2);
            box.PackEnd(innerBox);
            innerBox.PackEnd(button3);


            button1.Show();
            button2.Show();
            button3.Show();

            box.KeyDown += (s, e) =>
            {
                System.Console.WriteLine("Key down {0} on box has onHold {1}", e.KeyName, e.Flags);
            };
            button1.KeyDown += (s, e) =>
            {
                System.Console.WriteLine("Key down {0} on button1 has onHold {1}", e.KeyName, e.Flags);
                e.Flags = EvasEventFlag.OnHold;
            };
            button2.KeyDown += (s, e) =>
            {
                System.Console.WriteLine("Key down {0} on button2 has onHold {1}", e.KeyName, e.Flags);
            };
            button3.KeyDown += (s, e) =>
            {
                System.Console.WriteLine("Key down {0} on button3 has onHold {1}", e.KeyName, e.Flags);
            };
            innerBox.KeyDown += (s, e) =>
            {
                System.Console.WriteLine("Key down {0} on innerbox has onHold {1}", e.KeyName, e.Flags);
                e.Flags = EvasEventFlag.OnHold;
            };


        }
    }
}
