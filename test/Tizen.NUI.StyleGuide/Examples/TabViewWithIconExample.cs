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
    internal class TabViewWithIconExample : ContentPage, IExample
    {
        private const int maxTabCount = 4;
        private const int colorOne = 0, colorTwo = 1, colorThree = 2;
        private int tabCount = 0;
        private TabView tabView;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public TabViewWithIconExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "TabView Default Style",
            };

            tabView = new TabView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            Content = tabView;

            tabView.AddTab(CreateTabButton(), CreateView());
            tabCount++;

            tabView.AddTab(CreateTabButton(), CreateView());
            tabCount++;
        }

        private TabButton CreateTabButton()
        {
            return new TabButton()
            {
                Text = "Tab" + (tabCount + 1),
                IconURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "home.png",
            };
        }

        private View CreateView()
        {
            Color backgroundColor;
            Color buttonBackgroundColor;

            if ((tabCount + 1) % maxTabCount == colorOne)
            {
                backgroundColor = Color.DarkGreen;
                buttonBackgroundColor = Color.Green;
            }
            else if ((tabCount + 1) % maxTabCount == colorTwo)
            {
                backgroundColor = Color.DarkRed;
                buttonBackgroundColor = Color.Red;
            }
            else if ((tabCount + 1) % maxTabCount == colorThree)
            {
                backgroundColor = Color.DarkBlue;
                buttonBackgroundColor = Color.Blue;
            }
            else
            {
                backgroundColor = Color.SaddleBrown;
                buttonBackgroundColor = Color.Orange;
            }

            var container = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(0, 20),
                },
                BackgroundColor = backgroundColor,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            var buttonAddTab = new Button()
            {
                Text = "Add Tab",
                BackgroundColor = buttonBackgroundColor,
            };
            buttonAddTab.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount < maxTabCount)
                {
                    tabView.AddTab(CreateTabButton(), CreateView());
                    tabCount++;
                }
            };
            container.Add(buttonAddTab);

            var buttonRemoveTab = new Button()
            {
                Text = "Remove Tab",
                BackgroundColor = buttonBackgroundColor,
            };
            buttonRemoveTab.Clicked += (object sender, ClickedEventArgs args) =>
            {
                if (tabCount > 1)
                {
                    tabView.RemoveTab(tabCount - 1);
                    tabCount--;
                }
            };
            container.Add(buttonRemoveTab);

            return container;
        }

    }
}
