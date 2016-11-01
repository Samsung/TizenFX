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
    class GenListTest3 : TestCaseBase
    {
        public override string TestName => "GenListTest3";
        public override string TestDescription => "To test group operation of GenList";

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

            GenItemClass groupClass = new GenItemClass("group_index")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                }
            };

            GenListItem[] groups = new GenListItem[10];

            for (int i = 0; i< 10; i++)
            {
                groups[i] = list.Append(groupClass, string.Format("{0}", i) , GenListItemType.Group);
            }
            
            
            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                },
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("{0} - {1}", (string)obj, part);
                    return null;
                }
            };

            GenItemClass fullyCustomizeClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("{0} part create requested", part);
                    var btn = new Button(window) {
                        Text = "Button in List",
                        AlignmentX = -1,
                        WeightX = 1,
                    };
                    return btn;
                }
            };

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    list.Append( j == 0 ? fullyCustomizeClass : defaultClass, string.Format("{0} Item", i), GenListItemType.Normal, groups[j]);
                }
            }

            list.Show();
            list.ItemSelected += List_ItemSelected; ;
            conformant.SetContent(list);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
