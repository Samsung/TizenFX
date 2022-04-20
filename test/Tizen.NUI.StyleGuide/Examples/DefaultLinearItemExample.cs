/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class DefaultLinearItemExample : ContentPage, IExample
    {
        private Window window;
        public void Activate()
        {
        }
        public void Deactivate()
        {
            window = null;
        }
        DefaultLinearItem CreateItem(string text, string subText = null, bool icon = false, bool extra = false)
        {
            var item = new DefaultLinearItem()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = text,
            };
            if (subText != null) item.SubText = subText;
            if (icon) item.Icon = new CheckBox();
            if (extra) item.Extra = new RadioButton();
            return item;
        }

        void CreateItems(View parent, string text, string subText = null, bool icon = false, bool extra = false)
        {
            var enabledItem = CreateItem("Enabled "+ text, subText, icon, extra);
            enabledItem.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Enabled Item Clicked\n");
            };
            parent.Add(enabledItem);

            var disabledItem = CreateItem("Disabled "+ text, subText, icon, extra);
            disabledItem.IsEnabled = false;
            parent.Add(disabledItem);

            var selectedItem = CreateItem("Selected "+ text, subText, icon, extra);
            selectedItem.IsSelectable = true;
            selectedItem.IsSelected = true;
            selectedItem.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                selectedItem.Text = (selectedItem.IsSelected?"Selected ":"Unselected ") + text;
            };
            parent.Add(selectedItem);
        }

        /// Modify this method for adding other examples.
        public DefaultLinearItemExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "DefaultLinearItem Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            var rootContent = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                HideScrollbar = false,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 20),
                },
            };

            CreateItems(rootContent, "Label Only");
            CreateItems(rootContent, "Label and SubLabel", "Lorem ipsum dolor sit amet, consectetur adipiscing elit");
            CreateItems(rootContent, "Label and Icon", null, true);
            CreateItems(rootContent, "Label and Extra", null, false, true);

            Content = rootContent;
        }
    }
}
