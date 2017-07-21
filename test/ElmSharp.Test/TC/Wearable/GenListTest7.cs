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

namespace ElmSharp.Test.Wearable
{
    class GenListTest7 : WearableTestCase
    {
        public override string TestName => "GenListTest7";
        public override string TestDescription => "To test basic operation of GenList";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            GenList list = new GenList(window)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            Button button = new Button(window)
            {
                Text = "Remove",
                AlignmentX = -1,
                AlignmentY = -1,
            };

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                }
            };

            GenListItem[] itemArr = new GenListItem[9];
            for (int i = 0; i < 9; i++)
            {
                itemArr[i] = list.Append(defaultClass, string.Format("{0} Item", i));
            }

            int idx = 0;
            button.Clicked += (s, e) =>
            {
                if (idx < 9)
                {
                    Console.WriteLine("GenListItem deleted");
                    itemArr[idx++].Delete();
                }
            };
            button.Show();

            list.Show();
            list.ItemSelected += List_ItemSelected;
            list.ItemRealized += List_ItemRealized;
            list.ItemUnrealized += List_ItemUnrealized;

            var square = window.GetInnerSquare();
            list.Geometry = new Rect(square.X, square.Y, square.Width, square.Height * 3 / 4);
            button.Geometry = new Rect(square.X, square.Y + square.Height * 3 / 4, square.Width, square.Height / 4);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
        private void List_ItemRealized(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was realized", (string)(e.Item.Data));
        }
        private void List_ItemUnrealized(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was unrealized", (string)(e.Item.Data));
        }
    }
}
