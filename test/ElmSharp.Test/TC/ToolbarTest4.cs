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
    public class ToolbarTest4 : TestCaseBase
    {
        public override string TestName => "ToolbarTest4";
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
                ShrinkMode = ToolbarShrinkMode.Scroll,
                IconLookupOrder = ToolbarIconLookupOrder.ThemeFreedesktop,
            };
            toolbar.Show();
            outterBox.PackEnd(toolbar);

            toolbar.Append("FirstItem", "home");
            toolbar.Append("LastItem", "home");
            ToolbarItem result = toolbar.InsertAfter(toolbar.FirstItem, "Result", "");

            Button bt1 = new Button(window)
            {
                Text = "Change IconSize",
                MinimumWidth = 400
            };
            bt1.Clicked += (s, e) =>
            {
                if (toolbar.IconSize < 50)
                    toolbar.IconSize = 100;
                else
                    toolbar.IconSize = 32;
                result.Text = string.Format("IconSize{0}", toolbar.IconSize.ToString());
            };
            bt1.Show();
            outterBox.PackEnd(bt1);

            Button bt2 = new Button(window)
            {
                Text = "Find FirstItem",
                MinimumWidth = 400
            };
            bt2.Clicked += (s, e) =>
            {
                ToolbarItem item1 = toolbar.FirstItem;
                ToolbarItem item2 = toolbar.FindItemByLabel("FirstItem");
                if (item1 == null || item2 == null || item1 != item2)
                    result.Text = "FAIL";
                else
                    result.Text = "PASS";
            };
            bt2.Show();
            outterBox.PackEnd(bt2);

            Button bt3 = new Button(window)
            {
                Text = "Find LastItem",
                MinimumWidth = 400
            };
            bt3.Clicked += (s, e) =>
            {
                ToolbarItem item1 = toolbar.LastItem;
                ToolbarItem item2 = toolbar.FindItemByLabel("LastItem");
                if (item1 == null || item2 == null || item1 != item2)
                    result.Text = "FAIL";
                else
                    result.Text = "PASS";
            };
            bt3.Show();
            outterBox.PackEnd(bt3);

            Button bt4 = new Button(window)
            {
                Text = "Get ItemsCount",
                MinimumWidth = 400
            };
            bt4.Clicked += (s, e) =>
            {
                result.Text = toolbar.ItemsCount.ToString();
            };
            bt4.Show();
            outterBox.PackEnd(bt4);

            Button bt5 = new Button(window)
            {
                Text = "Change IconLookupOrder",
                MinimumWidth = 400
            };
            bt5.Clicked += (s, e) =>
            {
                toolbar.IconLookupOrder = (ToolbarIconLookupOrder)(((int)toolbar.IconLookupOrder + 1) % 4);
                result.Text = toolbar.IconLookupOrder.ToString();
            };
            bt5.Show();
            outterBox.PackEnd(bt5);

            conformant.SetContent(outterBox);
        }
    }
}
