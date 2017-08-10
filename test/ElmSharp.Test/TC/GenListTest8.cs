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
    class GenListTest8 : TestCaseBase
    {

        Dictionary<EvasObject, Button> _cacheMap = new Dictionary<EvasObject, Button>();
        public override string TestName => "GenListTest8";
        public override string TestDescription => "To test group operation of GenList";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                Color = Color.White,
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
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
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
                    Console.WriteLine("{0} part create requested", part);
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
                    Console.WriteLine("{0} part reuse requested", part);
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
            list.ItemSelected += List_ItemSelected; ;
            box.Show();
            box.PackEnd(check);
            box.PackEnd(list);
            conformant.SetContent(box);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
