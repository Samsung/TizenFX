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

namespace ElmSharp.Test
{
    class MultiButtonEntryTest1 : TestCaseBase
    {
        public override string TestName => "MultiButtonEntryTest1";
        public override string TestDescription => "To test basic operation of MultiButtonEntry";

        public override void Run(Window window)
        {
            Background bg = new Background(window);
            bg.Color = Color.White;
            bg.Move(0, 0);
            bg.Resize(window.ScreenSize.Width, window.ScreenSize.Height);
            bg.Show();

            MultiButtonEntry mbe = new MultiButtonEntry(window)
            {
                IsEditable = true,
                IsExpanded = true,
                Text = "To: "
            };

            var test = mbe.Append("test");
            mbe.Prepend("prepend");
            mbe.Append("append");
            mbe.InsertBefore(test, "insertBefore");
            mbe.InsertAfter(test, "insertAfter");

            mbe.ItemSelected += (s, e) =>
            {
                Console.WriteLine("item selected: " + e.Item.Label);
                if (e.Item.Next != null)
                    Console.WriteLine("next item: " + e.Item.Next);
                if (e.Item.Prev != null)
                    Console.WriteLine("next item: " + e.Item.Prev);
            };

            mbe.ItemClicked += (s, e) =>
            {
                Console.WriteLine("item clicked: " + e.Item.Label);
            };

            mbe.ItemLongPressed += (s, e) =>
            {
                Console.WriteLine("item longpressed: " + e.Item.Label);
            };

            mbe.ItemAdded += (s, e) =>
            {
                Console.WriteLine("item added: " + e.Item.Label);
            };

            mbe.ItemDeleted += (s, e) =>
            {
                Console.WriteLine("item deleted: " + e.Item.Label);
            };

            mbe.AppendFilter((label) =>
            {
                if (label.Contains("a"))
                {
                    Console.WriteLine("appended filter : Item has 'a', It won't be added until 'a' is removed.");
                    return false;
                }
                else
                {
                    return true;
                }
            });

            mbe.PrependFilter((label) =>
            {
                if (label.Contains("p"))
                {
                    Console.WriteLine("prepended filter : Item has 'p', It won't be added until 'p' is removed.");
                    return false;
                }
                else
                {
                    return true;
                }
            });

            Label label1 = new Label(window)
            {
                Text = "MultiButtonEntry Test",
                Color = Color.Blue
            };

            label1.Resize(600, 100);
            label1.Move(50, 50);
            label1.Show();

            mbe.Resize(600, 600);
            mbe.Move(0, 100);
            mbe.Show();
        }
    }
}