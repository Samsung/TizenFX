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
    class GenListTest11 : TestCaseBase
    {
        public override string TestName => "GenListTest11";
        public override string TestDescription => "To test InsertSorted operation of GenList";

        public int myCompare(object t1, object t2)
        {
            int c1 = Convert.ToInt32((string)t1);
            int c2 = Convert.ToInt32((string)t2);

            return c1 - c2;
        }

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

            List<GenListItem> items = new List<GenListItem>();
            int idx = 20;
            for (int t = 1; t < 10; t++)
            {
                items.Add(list.InsertSorted(defaultClass, idx.ToString(), myCompare, GenListItemType.Normal, null));
                idx--;
            }
            list.Show();
            list.ItemSelected += List_ItemSelected;

            box.PackEnd(list);
            Button first = new Button(window)
            {
                Text = "Check first and last item",
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
                items.Add(list.InsertSorted(defaultClass, idx.ToString(), myCompare, GenListItemType.Normal, null));
                idx--;
            };

            first.Clicked += (s, e) =>
            {
                Console.WriteLine("Last Item's Data : " + list.LastItem.Data);
                Console.WriteLine("First date of Items " + items[0].Data);
                Console.WriteLine("Result for comparinson " + (bool)(list.LastItem == list.LastItem));
            };

            first.Show();
            Add.Show();
            box.PackEnd(first);
            box.PackEnd(Add);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
