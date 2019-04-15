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
    class GenListTest12 : TestCaseBase
    {
        public override string TestName => "GenListTest12";
        public override string TestDescription => "To test basic operation of GenListItem's ClearSubitems method";

        public override void Run(Window window)
        {
            Console.WriteLine("AA");
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
                    return string.Format("{0} - {1}", obj, part);
                },
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("{0} - {1}", obj, part);

                    return null;
                }
            };

            GenListItem treeItem = list.Append(defaultClass, "TreeItem", GenListItemType.Tree);
            for (int i = 0; i < 5; i++)
            {
                list.Append(defaultClass, i, GenListItemType.Normal, treeItem);
            }

            list.Show();
            box.PackEnd(list);

            Button first = new Button(window)
            {
                Text = "Check first and last item",
                AlignmentX = -1,
                WeightX = 1,
            };

            first.Clicked += (s, e) =>
            {
                Console.WriteLine("Before : " + (list.LastItem.Index - list.FirstItem.Index + 1).ToString());
                treeItem.ClearSubitems();
                Console.WriteLine("After : " + (list.LastItem.Index - list.FirstItem.Index + 1).ToString());
            };
            first.Show();
            box.PackEnd(first);
        }
    }
}
