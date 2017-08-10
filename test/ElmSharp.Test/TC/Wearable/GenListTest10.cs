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
using System.Collections.Generic;
using ElmSharp;

namespace ElmSharp.Test.Wearable
{
    class GenListTest10 : WearableTestCase
    {
        public override string TestName => "GenListTest10";
        public override string TestDescription => "To test InsertBefore operation of GenList with full style";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            GenList list = new GenList(window)
            {
                Homogeneous = false,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass defaultClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("{0} part create requested", part);
                    var btn = new Button(window)
                    {
                        Text = obj.ToString(),
                        AlignmentX = -1,
                        WeightX = 1,
                    };
                    return btn;
                }
            };

            GenItemClass headerClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("{0} part create requested", part);
                    var btn = new Button(window)
                    {
                        Text = obj.ToString(),
                        AlignmentX = -1,
                        WeightX = 1,
                    };
                    btn.Show();

                    var label = new Label(window)
                    {
                        Text = "GenItem with full style"
                    };
                    label.Show();

                    Box hBox = new Box(window)
                    {
                        AlignmentX = -1,
                        AlignmentY = -1,
                        WeightX = 1,
                        WeightY = 1,
                    };
                    hBox.Show();
                    hBox.PackEnd(btn);
                    hBox.PackEnd(label);
                    return hBox;
                }

            };

            List<GenListItem> itemList = new List<GenListItem>();
            GenListItem firstItem = null;

            for (int i = 0; i < 5; i++)
            {
                GenListItem now = list.Append(defaultClass, string.Format("{0} Item", i));
                itemList.Add(now);

                if (firstItem == null)
                {
                    firstItem = now;
                }
            }
            list.Show();
            list.ItemSelected += List_ItemSelected;

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

            first.Clicked += (s, e) =>
            {
                firstItem = list.InsertBefore(headerClass, "Header", firstItem);
            };
            last.Clicked += (s, e) =>
            {
                list.Append(headerClass, "Footer");
            };

            first.Show();
            last.Show();

            var square = window.GetInnerSquare();
            list.Geometry = new Rect(square.X, square.Y, square.Width, square.Height * 3 / 4);
            first.Geometry = new Rect(square.X, square.Y + square.Height * 3 / 4, square.Width / 2, square.Height / 4);
            last.Geometry = new Rect(square.X + square.Width / 2, square.Y + square.Height * 3 / 4, square.Width / 2, square.Height / 4);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
