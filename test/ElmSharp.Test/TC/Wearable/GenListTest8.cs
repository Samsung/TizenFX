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
    class GenListTest8 : WearableTestCase
    {

        Dictionary<EvasObject, Button> _cacheMap = new Dictionary<EvasObject, Button>();
        public override string TestName => "GenListTest8";
        public override string TestDescription => "To test group operation of GenList";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                Color = Color.Gray,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            bg.Show();
            bg.Lower();

            window.AddResizeObject(bg);
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Check check = new Check(window);
            check.Show();
            check.IsChecked = true;
            check.Text = "Reuse?";

            GenList list = new GenList(window)
            {
                Homogeneous = false,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass fullyCustomizeClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Log.Debug(string.Format("{0} part create requested", part));
                    var btn = new Button(window)
                    {
                        AlignmentX = -1,
                        WeightX = 1,
                        Text = (string)obj
                    };
                    return btn;
                },
                ReusableContentHandler = (object data, string part, EvasObject old) =>
                {
                    Log.Debug(string.Format("{0} part reuse requested", part));
                    if (!check.IsChecked)
                    {
                        return null;
                    }
                    var btn = old as Button;
                    btn.Text = (string)data;
                    return old;
                }
            };

            for (int i = 0; i < 100; i++)
            {
                list.Append(fullyCustomizeClass, string.Format("{0} Item", i), GenListItemType.Normal);
            }

            list.Show();
            list.ItemSelected += List_ItemSelected;

            var square = window.GetInnerSquare();

            check.Geometry = new Rect(square.X, square.Y, square.Width, square.Height / 4);
            list.Geometry = new Rect(square.X, square.Y + square.Height / 4, square.Width, square.Height * 3 / 4);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was selected", (string)(e.Item.Data)));
        }
    }
}
