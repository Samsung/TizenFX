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
    public class TableTest1 : TestCaseBase
    {
        public override string TestName => "TableTest1";
        public override string TestDescription => "To test basic operation of Table";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Table table = new Table(window) {
                PaddingX = 10,
                PaddingY = 10
            };
           // table.BackgroundColor = Color.Orange;
            conformant.SetContent(table);
            table.Show();

            Button button1 = new Button(window) {
                Text = "Button (set Color.Oranage)",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            button1.Clicked += (e,o) =>
            {
                table.BackgroundColor = Color.Orange;
                Console.WriteLine("{0} Clicked! - Button's BG Color : {1}, Table's BG Color : {2}", ((Button)e).Text, ((Button)e).BackgroundColor, table.BackgroundColor);
            };

            Button button2 = new Button(window) {
                Text = "Button 2 (set Color.Defalut)",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = new Color(50, 100, 200, 75)
            };
            button2.Clicked += (e, o) =>
            {
                table.BackgroundColor = Color.Default;
                Console.WriteLine("{0} Clicked! - Button's BG Color : {1}, Table's BG Color : {2}", ((Button)e).Text, ((Button)e).BackgroundColor, table.BackgroundColor);
            };

            table.Pack(button1,0,0,3,3);
            table.Pack(button2,3,1,1,1);

            button1.Show();
            button2.Show();
        }
    }
}
