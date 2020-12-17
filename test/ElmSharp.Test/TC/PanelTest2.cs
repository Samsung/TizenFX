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
    public class PanelTest2 : TestCaseBase
    {
        public override string TestName => "PanelTest2";
        public override string TestDescription => "To test basic operation of Panel";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            //Label label = new Label(window)
            //{
            //    Text = "<span color=#ffffff font_size=50>Panel as Scrollable</span>",
            //    AlignmentX = -1,
            //    WeightX = 1,
            //};
            //label.Show();
            //box.PackEnd(label);

            Panel panel = new Panel(window)
            {
                Direction = PanelDirection.Left,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };


            panel.SetScrollable(false);
            panel.SetScrollable(true);
            panel.SetScrollableArea(1.0);

            Rectangle redbox = new Rectangle(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Red,
            };
            redbox.Show();
            panel.SetContent(redbox);
            panel.Show();
            panel.IsOpen = true;
            box.PackEnd(panel);

            Button button1 = new Button(window)
            {
                Text = "Toggle open",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };
            Button button2 = new Button(window)
            {
                Text = "Toggle direction",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
            };
            box.PackEnd(button1);
            box.PackEnd(button2);
            button1.Show();
            button2.Show();

            button1.Clicked += (s, e) =>
            {
                panel.Toggle();
            };
            button2.Clicked += (s, e) =>
            {
                panel.Direction = (PanelDirection)((int)(panel.Direction + 1) % 4);
            };
            panel.Toggled += (s, e) =>
            {
                Console.WriteLine("Panel Toggled!");
            };
            panel.Scrolled += (s, e) =>
            {
                Console.WriteLine("Panel Scrolled! : IsOpen = " + panel.IsOpen);
            };
        }

    }
}
