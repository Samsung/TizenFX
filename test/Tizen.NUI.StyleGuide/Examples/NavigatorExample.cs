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
    internal class NavigatorExample : ContentPage, IExample
    {
        private const int numberOfDifferentColor = 4;
        private const int colorOne = 0, colorTwo = 1, colorThree = 2;
        private Navigator navigator;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public NavigatorExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Navigator Default Style",
            };

            navigator = NUIApplication.GetDefaultWindow().GetDefaultNavigator();
            Content = generatePage();
        }

        private ContentPage generatePage()
        {
            var page = new ContentPage();
            page.AppBar = new AppBar()
            {
                Title = "NavigatorTestPage",
            };

            var contentView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 10),
                },
            };
            page.Content = contentView;

            var buttonPush = new Button()
            {
                Text = "Push",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            buttonPush.Clicked += (s, e) =>
            {
                if (navigator == null)
                {
                    Tizen.Log.Error("NUITEST", "The page should be pushed to a Navigator");
                    return;
                }
                var newPage = generatePage();
                newPage.AppBar.Title = "NavigatorTestPage" + navigator.PageCount.ToString();
                navigator.Push(newPage);
            };
            contentView.Add(buttonPush);

            var buttonPop = new Button()
            {
                Text = "Pop",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            buttonPop.Clicked += (s, e) =>
            {
                if (navigator == null)
                {
                    Tizen.Log.Error("NUITEST", "The page should be pushed to a Navigator");
                    return;
                }
                navigator.Pop();
            };
            contentView.Add(buttonPop);

            Color backgroundColor;
            switch (navigator.PageCount % numberOfDifferentColor)
            {
                case colorOne:
                    backgroundColor = Color.DarkGreen;
                    break;
                case colorTwo:
                    backgroundColor = Color.DarkRed;
                    break;
                case colorThree:
                    backgroundColor = Color.DarkBlue;
                    break;
                default:
                    backgroundColor = Color.SaddleBrown;
                    break;
            };
            buttonPush.BackgroundColor = backgroundColor;
            buttonPop.BackgroundColor = backgroundColor;
            return page;
        }
    }
}
