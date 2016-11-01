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
    public class NaviframeTest2 : TestCaseBase
    {
        public override string TestName => "NaviframeTest2";
        public override string TestDescription => "Naviframe test";

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

            Label label = new Label(parent) {
                Text = string.Format("{0} Page", _sequence++),
                WeightX = 1,
                AlignmentX = -1,
            };
            Button push = new Button(parent) {
                Text = "Push",
                WeightX = 1,
                AlignmentX = -1,
            };
            Button pop = new Button(parent) {
                Text = "pop",
                WeightX = 1,
                AlignmentX = -1,
            };
            Button insertBeforeTop = new Button(parent) {
                Text = "insertBeforeTop",
                WeightX = 1,
                AlignmentX = -1,
            };
            Button insertAfterTop = new Button(parent) {
                Text = "insertAfterTop",
                WeightX = 1,
                AlignmentX = -1,
            };

            Button removeTop = new Button(parent)
            {
                Text = "removeTop",
                WeightX = 1,
                AlignmentX = -1,
            };

            label.Show();
            push.Show();
            pop.Show();
            insertBeforeTop.Show();
            insertAfterTop.Show();
            removeTop.Show();

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
            
            box.PackEnd(label);
            box.PackEnd(push);
            box.PackEnd(pop);
            box.PackEnd(insertBeforeTop);
            box.PackEnd(insertAfterTop);
            box.PackEnd(removeTop);

            return box;
        }
    }
}
