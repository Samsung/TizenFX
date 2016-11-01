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
using System.Linq;

namespace ElmSharp.Test
{
    public class BoxLayoutTest1 : TestCaseBase
    {
        public override string TestName => "BoxLayoutTest1";
        public override string TestDescription => "Box Layout callback test";

        Naviframe _navi;
        int _sequence = 0;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };
            _navi = navi;

            navi.Popped += (s, e) =>
            {
                Console.WriteLine("----- Naviframe was popped {0:x} ", (int)(IntPtr)e.Content);
            };

            navi.Push(CreatePage(window), "0 Page");
            navi.Show();
            conformant.SetContent(navi);
        }

        EvasObject CreatePage(Window parent)
        {
            Box box = new Box(parent);
            box.Show();

            Label label = new Label(parent)
            {
                Text = string.Format("{0} Page", _sequence++),
                WeightX = 1,
                AlignmentX = -1,
            };
            Button push = new Button(parent)
            {
                Text = "Push",
                WeightX = 1,
                AlignmentX = -1,
            };
            Button pop = new Button(parent)
            {
                Text = "pop",
                WeightX = 1,
                AlignmentX = -1,
            };

            label.Show();
            push.Show();
            pop.Show();

            push.Clicked += (s, e) =>
            {
                _navi.Push(CreatePage(parent), string.Format("{0} Page", _sequence - 1));
            };

            pop.Clicked += (s, e) =>
            {
                var item = _navi.NavigationStack.LastOrDefault();
                int nativePointer = (int)(IntPtr)(item.Content);
                Console.WriteLine("----- Before Call _navi.Pop() {0:x} ", nativePointer);
                _navi.Pop();
                Console.WriteLine("----- After Call _navi.Pop() {0:x} ", nativePointer);
            };

            push.Resize(500, 100);
            pop.Resize(500, 100);
            label.Resize(500, 100);
            box.SetLayoutCallback(() =>
            {
                Console.WriteLine("Layout callback with : {0}", box.Geometry);
                var rect = box.Geometry;
                label.Move(rect.X, rect.Y);
                push.Move(rect.X, rect.Y + 100);
                pop.Move(rect.X, rect.Y + 200);
            });

            box.PackEnd(label);
            box.PackEnd(push);
            box.PackEnd(pop);
            return box;
        }
    }
}
