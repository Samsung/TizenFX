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

namespace ElmSharp.Test.Wearable
{
    public class NaviframeTest3 : WearableTestCase
    {
        public override string TestName => "NaviframeTest3";
        public override string TestDescription => "Naviframe test";

        Naviframe _navi;
        int _sequence = 0;
        Rect square;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            square = window.GetInnerSquare();

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

            NaviItem item = navi.Push(CreatePage(window), "0 Page");
            item.SetPartContent("title_left_btn", new Button(window) { Text = "LEFT" , Style = "naviframe/title_left"} );
            item.SetPartContent("title_right_btn", new Button(window) { Text = "RIGHT", Style = "naviframe/title_right" });
            navi.Show();
            conformant.SetContent(navi);
        }

        EvasObject CreatePage(Window parent)
        {
            Table table = new Table(parent);
            table.Geometry = square;
            table.Show();

            Label label = new Label(parent) {
                Text = string.Format("<span color=#000000 font_size=15>{0} Page</span>", _sequence++),
                WeightX = 1,
                AlignmentX = -1,
            };
            Button push = new Button(parent) {
                Text = "<span color=#000000 font_size=15>Push</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };
            Button pop = new Button(parent) {
                Text = "<span color=#000000 font_size=15>pop</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };
            Button insertBeforeTop = new Button(parent) {
                Text = "<span color=#000000 font_size=15>insertBeforeTop</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };
            Button insertAfterTop = new Button(parent) {
                Text = "<span color=#000000 font_size=15>insertAfterTop</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };

            Button removeTop = new Button(parent)
            {
                Text = "<span color=#000000 font_size=15>removeTop</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };

            Button barChange = new Button(parent)
            {
                Text = "<span color=#000000 font_size=15>TitleBarColor Change</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };

            Button barColorDefault = new Button(parent)
            {
                Text = "<span color=#000000 font_size=15>TitleBarColor - Default</span>",
                WeightX = 1,
                AlignmentX = -1,
                BackgroundColor = Color.Black,
            };

            label.Show();
            push.Show();
            pop.Show();
            insertBeforeTop.Show();
            insertAfterTop.Show();
            removeTop.Show();
            barChange.Show();
            barColorDefault.Show();

            push.Clicked += (s, e) =>
            {
                _navi.Push(CreatePage(parent), string.Format("{0} Page", _sequence-1));
            };

            pop.Clicked += (s, e) =>
            {
                var item = _navi.NavigationStack.LastOrDefault();
                int nativePointer = (int)(IntPtr)(item.Content);
                Console.WriteLine("----- Before Call _navi.Pop() {0:x} ", nativePointer);
                _navi.Pop();
                Console.WriteLine("----- After Call _navi.Pop() {0:x} ", nativePointer);
            };

            insertBeforeTop.Clicked += (s, e) =>
            {
                _navi.InsertBefore(_navi.NavigationStack.LastOrDefault(), CreatePage(parent), string.Format("{0} Page", _sequence - 1));
            };

            insertAfterTop.Clicked += (s, e) =>
            {
                _navi.InsertAfter(_navi.NavigationStack.LastOrDefault(), CreatePage(parent), string.Format("{0} Page", _sequence - 1));
            };
            removeTop.Clicked += (s, e) =>
            {
                var item = _navi.NavigationStack.LastOrDefault();
                int nativePointer = (int)(IntPtr)(item.Content);
                Console.WriteLine("----- Before Call NaviItem.Delete() {0:x} ", nativePointer);
                item.Delete();
                Console.WriteLine("----- After Call NaviItem.Delete() {0:x} ", nativePointer);
            };

            Random rand = new Random(DateTime.Now.Millisecond);
            barChange.Clicked += (s, e) =>
            {
                int currentIndex = _navi.NavigationStack.Count - 1;
                if (currentIndex >= 0)
                {
                    _navi.NavigationStack[currentIndex].TitleBarBackgroundColor = Color.FromHex(string.Format("#{0:X8}", rand.Next()));
                }
            };

            barColorDefault.Clicked += (s, e) =>
            {
                int currentIndex = _navi.NavigationStack.Count - 1;
                if (currentIndex >= 0)
                {
                    _navi.NavigationStack[currentIndex].TitleBarBackgroundColor = Color.Default;
                }
            };

            table.Pack(label, 0, 0, 1, 1);
            table.Pack(push, 0, 1, 1, 1);
            table.Pack(pop, 1, 1, 1, 1);
            table.Pack(insertBeforeTop, 0, 2, 1, 1);
            table.Pack(insertAfterTop, 1, 2, 1, 1);
            table.Pack(removeTop, 0, 3, 1, 1);
            table.Pack(barChange, 0, 4, 1, 1);
            table.Pack(barColorDefault, 1, 4, 1, 1);

            return table;
        }
    }
}
