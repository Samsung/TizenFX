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
    internal class MenuExample : ContentPage, IExample
    {
        private View rootContent;
        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public MenuExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Menu Default Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            rootContent = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 20),
                },
            };

            Content = rootContent;


            var pageContent = new Button()
            {
                Text = "Page Content",
                CornerRadius = 0,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            var moreButton = new Button()
            {
                Text = "More",
            };

            var appBar = new AppBar()
            {
                AutoNavigationContent = false,
                Title = "Title",
                Actions = new View[] { moreButton, },
            };

            var page = new ContentPage()
            {
                AppBar = appBar,
                Content = pageContent,
            };

            rootContent.Add(page);

            var menuItem = new MenuItem() { Text = "Menu" };
            menuItem.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"1st MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            var menuItem2 = new MenuItem() { Text = "Menu2" };
            menuItem2.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"2nd MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            var menuItem3 = new MenuItem() { Text = "Menu3" };
            menuItem3.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"3rd MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            var menuItem4 = new MenuItem() { Text = "Menu4" };
            menuItem4.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"4th MenuItem's IsSelected is changed to {args.IsSelected}.");
            };

            moreButton.Clicked += (object sender, ClickedEventArgs args) =>
            {
                var menu = new Menu()
                {
                    Anchor = moreButton,
                    HorizontalPositionToAnchor = Menu.RelativePosition.Center,
                    VerticalPositionToAnchor = Menu.RelativePosition.End,
                    Items = new MenuItem[] { menuItem, menuItem2, menuItem3, menuItem4 },
                };
                menu.Post();
            };
        }
    }
}
