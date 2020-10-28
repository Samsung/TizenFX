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

namespace ElmSharp.Test.Wearable
{
    class IndexTest1 : WearableTestCase
    {
        Dictionary<IndexItem, GenListItem> _indexTable = new Dictionary<IndexItem, GenListItem>();
        public override string TestName => "IndexTest1";
        public override string TestDescription => "To test group operation of Index";
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
                IsHorizontal = true,
            };
            box.Show();
            GenList list = new GenList(window)
            {
                Homogeneous = false,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            list.Show();
            Index index = new Index(window)
            {
                IsHorizontal = false,
                AlignmentY = -1,
                WeightY = 1,
                MinimumWidth = 100,
                AutoHide = false,
                Style = "fastscroll"
            };
            index.Show();

            GenItemClass groupClass = new GenItemClass("group_index")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                }
            };

            GenListItem[] groups = new GenListItem[10];

            for (int i = 0; i < 10; i++)
            {
                groups[i] = list.Append(groupClass, string.Format("{0}", i), GenListItemType.Group);
                var indexitem = index.Append(string.Format("{0}", i));
                indexitem.Selected += (s, e) =>
                {
                    Console.WriteLine("Index selected : {0}", ((IndexItem)s).Text);
                    list.ScrollTo(_indexTable[(IndexItem)s], ScrollToPosition.In, true);
                };
                _indexTable[indexitem] = groups[i];
            }

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                }
            };

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    list.Append(defaultClass, string.Format("{0} Item", i), GenListItemType.Normal, groups[j]);
                }
            }

            list.ItemSelected += List_ItemSelected;
            index.Update(0);
            box.PackEnd(list);
            box.PackEnd(index);
            box.SetLayoutCallback(() =>
            {
                list.Geometry = box.Geometry;
                index.Geometry = box.Geometry;
            });
            conformant.SetContent(box);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
