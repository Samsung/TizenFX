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
    internal class AppBarExample : ContentPage, IExample
    {
        private View rootContent;
        private AppBar appBar;
        private TextLabel label;
        private Button button;
        private int count;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public AppBarExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "AppBar Default Style",
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

            // AppBar examples.
            appBar = new AppBar()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Title = "This is AppBar",
                AutoNavigationContent = false,
            };
            rootContent.Add(appBar);

            label = new TextLabel
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = $"title: {appBar.Title}"
            };
            rootContent.Add(label);

            button = new Tizen.NUI.Components.Button
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = "change title"
            };
            rootContent.Add(button);

            button.Clicked += (s, e) =>
            {
                appBar.Title = $"This is AppBar(clk {count++})";
                label.Text = $"title: {appBar.Title}";
            };

            Content = rootContent;
        }
    }
}
