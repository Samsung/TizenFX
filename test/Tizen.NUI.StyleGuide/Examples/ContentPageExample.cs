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
    internal class ContentPageExample : ContentPage, IExample
    {
        private Window window;
        private Navigator navigator;
        private ContentPage contentPage1, contentPage2;
        private int pageCount = 0;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public ContentPageExample() : base()
        {
            window = NUIApplication.GetDefaultWindow();

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "ContentPage Default Style",
            };

            navigator = window.GetDefaultNavigator();
            pageCount = navigator.PageCount;

            contentPage1 = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "ContentPageTestPage1",
                },
            };
            var buttonOne = new Button()
            {
                Text = "ONE",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            buttonOne.Clicked += (s, e) =>
            {
                navigator?.Push(contentPage2);
            };

            contentPage1.Content = buttonOne;

            contentPage2 = new ContentPage()
            {
                AppBar = new AppBar()
                {
                    Title = "ContentPageTestPage2",
                },
            };
            var buttonTwo = new Button()
            {
                Text = "TWO",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            buttonTwo.Clicked += (s, e) =>
            {
                navigator?.Pop();
            };
            contentPage2.Content = buttonTwo;

            Content = contentPage1;
        }
    }
}
