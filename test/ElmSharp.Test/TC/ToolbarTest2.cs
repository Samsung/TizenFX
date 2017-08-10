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
            Box outerBox = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = false,
                BackgroundColor = Color.Aqua,
            };
            outerBox.Show();

            Toolbar toolbar = new Toolbar(window)
            {
                AlignmentX = -1,
                WeightX = 1,
            };
            toolbar.Show();
            outerBox.PackEnd(toolbar);

            List<ToolbarItem> items = new List<ToolbarItem>();
            items.Add(toolbar.Append(string.Format("{0} home", items.Count), "home"));

            Button bt = new Button(window)
            {
                Text = "Add ToolbarItem",
                MinimumWidth = 400
            };
            bt.Clicked += (s, e) =>
            {
                items.Add(toolbar.Append(string.Format("{0} home", items.Count), "home"));
            };

            Button removebt = new Button(window)
            {
                Text = "Remove first ToolbarItem",
                MinimumWidth = 400
            };
            removebt.Clicked += (s, e) =>
            {
                foreach (var cur in items)
                {
                    items.Remove(cur);
                    cur.Delete();
                    return;
                }
            };

            bt.Show();
            removebt.Show();
            outerBox.PackEnd(bt);
            outerBox.PackEnd(removebt);
            conformant.SetContent(outerBox);
        }
    }
}
