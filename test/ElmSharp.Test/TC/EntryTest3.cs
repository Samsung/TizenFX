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
    class EntryTest3 : TestCaseBase
    {
        public override string TestName => "EntryTest3";
        public override string TestDescription => "To test basic operation of Entry";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
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

            Entry entry = new Entry(window)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1,
                IsSingleLine = true,
                Text = "Hello, Tizen"
            };

            var btn = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1,
                Text = "Set Filter"
            };
            btn.Show();

            //var filter = new Entry.TextFilter(SetFilter);
            btn.Clicked += (s, e) =>
            {
                entry.AppendMarkUpFilter(SetFilter);
            };

            var btn1 = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1,
                Text = "Remove Filter"
            };
            btn1.Show();
            btn1.Clicked += (s, e) =>
            {
                entry.RemoveMarkUpFilter(SetFilter);
            };

            //entry.AppendMarkUpFilter(new Entry.Filter(SetFilter));

            entry.Show();
            box.PackEnd(entry);
            box.PackEnd(btn);
            box.PackEnd(btn1);
        }

        public string SetFilter(Entry entry, string text)
        {
            if (text.Equals("a") || text.Equals("b") || text.Equals("c") || text.Equals("d"))
                return text;
            else
                return "Tizen";
        }
    }
}