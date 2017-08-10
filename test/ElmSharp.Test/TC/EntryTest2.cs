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
    class EntryTest2 : TestCaseBase
    {
        public override string TestName => "EntryTest2";
        public override string TestDescription => "To test basic operation of Entry";

        public override void Run(Window window)
        {
            Background bg = new Background(window) {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Yellow
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Check check = new Check(window) {
                AlignmentX = -1,
                AlignmentY = 0.9,
                WeightX = 1,
                WeightY = 0.1,
                Text = "Select All",
            };
            check.Show();

            Entry entry = new Entry(window) {
                AlignmentX = -1,
                AlignmentY = 0.1,
                WeightX = 1,
                WeightY = 1,
                IsSingleLine = true,
                Text = "Hello, Tizen !!!"
            };
            entry.Show();

            check.StateChanged += (object sender, CheckStateChangedEventArgs e) =>
            {
                if (e.NewState == true)
                {
                    entry.SelectAll();
                }
                else
                {
                    entry.SelectNone();
                }
            };

            box.PackEnd(check);
            box.PackEnd(entry);
        }
    }
}
