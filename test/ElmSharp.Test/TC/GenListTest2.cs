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
using System.Collections.Generic;

namespace ElmSharp.Test
{
    class GenListTest2 : TestCaseBase
    {
        public override string TestName => "GenListTest2";
        public override string TestDescription => "To test ScrollTo operation of GenList";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();
            conformant.SetContent(box);


            GenList list = new GenList(window)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                }
            };

            GenListItem[] items = new GenListItem[100];
            int i = 0;
            for (i = 0; i < 100; i++)
            {
                items[i] = list.Append(defaultClass, string.Format("{0} Item", i));
            }
            list.Show();
            list.ItemSelected += List_ItemSelected;

            GenListItem scroll = items[0];

            box.PackEnd(list);
            Button first = new Button(window)
            {
                Text = "First",
                AlignmentX = -1,
                WeightX = 1,
            };
            Button last = new Button(window)
            {
                Text = "last",
                AlignmentX = -1,
                WeightX = 1,
            };
            Button Add = new Button(window)
            {
                Text = "Add",
                AlignmentX = -1,
                WeightX = 1,
            };
            Add.Clicked += (s, e) =>
            {
                scroll = list.InsertBefore(defaultClass, string.Format("{0} Item", i++), scroll);
                list.ScrollTo(scroll, ScrollToPosition.In, false);
            };
            first.Clicked += (s, e) =>
            {
                list.ScrollTo(scroll, ScrollToPosition.In, true);
            };
            last.Clicked += (s, e) =>
            {
                list.ScrollTo(items[99], ScrollToPosition.In, true);
            };
            first.Show();
            last.Show();
            Add.Show();
            box.PackEnd(first);
            box.PackEnd(last);
            box.PackEnd(Add);

        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
