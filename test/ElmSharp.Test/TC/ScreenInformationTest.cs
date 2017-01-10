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
    public class ScreenInformationTest : TestCaseBase
    {
        public override string TestName => "ScreenInformationTest";
        public override string TestDescription => "To get screen information";

        Naviframe _navi;
        int _sequence = 0;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            box.Show();
            conformant.SetContent(box);
            Label label = new Label(window);
            label.SetAlignment(-1, 0);
            label.SetWeight(1, 0);
            label.Text = string.Format("<span color=#FFFFFF , font_size=50>ScreenSize : {0}x{1}", window.ScreenSize.Width, window.ScreenSize.Height);
            label.Show();
            box.PackEnd(label);
            Label label2 = new Label(window);
            label2.SetAlignment(-1, 0);
            label2.SetWeight(1, 0);
            label2.Text = string.Format("<span color=#FFFFFF , font_size=50>ScreenDPI : xdpi : {0} ydpi : {1}", window.ScreenDpi.X, window.ScreenDpi.Y);
            label2.Show();
            box.PackEnd(label2);
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
