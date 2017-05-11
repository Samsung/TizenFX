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
    public class ToolbarTest2 : TestCaseBase
    {
        Dictionary<ToolbarItem, int> _itemTable = new Dictionary<ToolbarItem, int>();
        Dictionary<int, ToolbarItem> _reverseItemTable = new Dictionary<int, ToolbarItem>();
        public override string TestName => "ToolbarTest2";
        public override string TestDescription => "To test basic operation of Toolbar";
        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box outterBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
                BackgroundColor = Color.Aqua,
            };
            outterBox.Show();

            Toolbar toolbar = new Toolbar(window)
            {
                AlignmentX = -1,
                WeightX = 1,
            };

            toolbar.Show();
            outterBox.PackEnd(toolbar);

            int idx = 1;
            ToolbarItem item = toolbar.Append(string.Format("{0} home", idx), "home");
            idx++;

            Button bt = new Button(window)
            {
                Text = "Add ToolbarItem",
                MinimumWidth = 400
            };
            bt.Clicked += (s, e) =>
            {
                ToolbarItem item2 = toolbar.Append(string.Format("{0} home", idx), "home");
                idx++;
            };

            bt.Show();
            outterBox.PackEnd(bt);
            conformant.SetContent(outterBox);
        }
    }
}
