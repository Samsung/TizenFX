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
    class GenListTest13 : TestCaseBase
    {
        public override string TestName => "GenListTest13";
        public override string TestDescription => "To test basic operation of GenList";

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

            GenItemClass entryClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("[entryClass] GetContentHandler ", obj);
                    var btn = new Entry(window)
                    {
                        Text = "This is Entry",
                        AlignmentX = -1,
                        WeightX = 1,
                        BackgroundColor = Color.Green
                    };
                    return btn;
                },
                ReusableContentHandler = (obj, part, old) =>
                {
                    Console.WriteLine("[entryClass] ReusableContentHandler ", obj);
                    return old;
                }
            };

            GenItemClass buttonClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("[buttonClass] GetContentHandler ", obj);
                    var btn = new Button(window)
                    {
                        Text = "This is Button",
                        AlignmentX = -1,
                        WeightX = 1,
                        MinimumHeight = 200,
                        BackgroundColor = Color.Pink
                    };
                    return btn;
                },
                ReusableContentHandler = (obj, part, old) =>
                {
                    Console.WriteLine("[buttonClass] ReusableContentHandler ", obj);
                    return old;
                }
            };

            for (int j = 0; j < 3; j++)
            {
                list.Append(buttonClass, string.Format("{0} Item", j), GenListItemType.Normal);
            }
            for (int j = 0; j < 3; j++)
            {
                list.Append(entryClass, string.Format("{0} Item", j), GenListItemType.Normal);
            }

            list.Show();
            conformant.SetContent(list);
        }
    }
}
