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
    internal class DefaultTitleItemExample : ContentPage, IExample
    {
        private Window window;
        public void Activate()
        {
        }
        public void Deactivate()
        {
            window = null;
        }

        /// Modify this method for adding other examples.
        public DefaultTitleItemExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "DefaultTitleItemExample Style",
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

            var item = new DefaultTitleItem()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = "Title Item",
            };
            rootContent.Add(item);

            var path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            var arrowStyle = new ButtonStyle()
            {
                IsSelectable = true,
                Size = new Size(40, 40),
                ItemHorizontalAlignment = HorizontalAlignment.Center,
                ItemVerticalAlignment = VerticalAlignment.Center,
                Icon = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>()
                    {
                        Normal = path + "/icon/icon_arrow_down.svg",
                        Pressed = path + "/icon/icon_arrow_up.svg",
                        Selected = path + "/icon/icon_arrow_up.svg",
                    }
                }
            };

            var itemWithArrow = new DefaultTitleItem()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = "Title Item With Arrow",
                EnableControlStatePropagation = true,
                Icon = new Button(arrowStyle)
                {
                    EnableControlStatePropagation = true,
                },
                IsSelectable = true,
            };
            rootContent.Add(itemWithArrow);

            Content = rootContent;
        }
    }
}
