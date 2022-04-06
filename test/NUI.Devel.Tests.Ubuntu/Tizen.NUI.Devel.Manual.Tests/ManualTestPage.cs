/*
 *  Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using global::System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using NUnitLite.TUnit;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;
using System.Collections.Generic;
using System.Reflection;
using Tizen.Applications;

namespace Tizen.NUI.Devel.Manual.Tests
{
    public class ManualTestPage : ContentPage
    {
        private string testName;
        private int testNumber;
        private ManualTestItem testItem;
        private TextEditor scenario;
        private View content;
        private View testContent;

        public ManualTestPage(ManualTestItem item) : base()
        {
            if (item == null) throw new ArgumentNullException();

            /**********************************************************************************************
            Test environment Setting
            ***********************************************************************************************/

            testName = item.TestCaseName;
            testNumber = item.TestIndex;
            testItem = item;

            /**********************************************************************************************
            Manual Test Page is constructed 4 individual parts.
            1. AppBar : appBar of ContentPage with title and navigation button.
                do not need to modify.
            2. Scenario Description : multiline textfields for describing scenario how to test.
            3. Test Content : content view which need to be tested.
                please inherit the class and decorate content view in virtual function SetUp().
            4. Result Button : click Pass if test was passed, click Fail if test was failed.
                do not need to modify
            ***********************************************************************************************/

            var navigator = NUIApplication.GetDefaultWindow().GetDefaultNavigator();

            AppBar = new AppBar()
            {
                Title = testName
            };

            var scrollableContent = new ScrollableBase()
            {
                HideScrollbar = false,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 20),
                }
            };

            scenario = new TextEditor()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color("#BFEFFF"),
                Text = SetScenario(),
                PointSize = 18,
                EnableEditing = false,
                Padding = new Extents(30, 30, 0, 0),
            };
            scrollableContent.Add(scenario);

            content = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.LightGrey,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                }
            };
            if (testContent != null)
            {
                content.Add(testContent);
            }
            scrollableContent.Add(content);

            var buttonBox = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                }
            };

            var passButton = new Button()
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                Text = "PASS",
            };
            passButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                TestResult(TestState.Passed);
                navigator.Pop();

            };
            buttonBox.Add(passButton);

            var failButton = new Button()
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                Text = "FAIL",
            };
            failButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                TestResult(TestState.Failed);
                navigator.Pop();
            };
            buttonBox.Add(failButton);

            scrollableContent.Add(buttonBox);

            Content = scrollableContent;
        }

        public string TestName
        {
            get => testName;
            set
            {
                testName = value;
                if (AppBar != null)
                {
                    AppBar.Title = testName;
                }
            }
        }

        public int TestNumber
        {
            get => testNumber;
            set => testNumber = value;
        }

        public View TestContent
        {
            get => content;
        }

        private string SetScenario()
        {
            string scenario = "";
            string newLine = "\n";

            foreach(string pre in testItem.PreConditions)
            {
                scenario += pre + newLine;
            }

            scenario  += newLine;

            foreach(string step in testItem.Steps)
            {
                scenario += step + newLine;
            }

            scenario  += newLine;


            foreach(string post in testItem.PostConditions)
            {
                scenario += post + newLine;
            }

            return scenario;
        }


        public void TestResult(TestState result)
        {
            if (BindingContext != null && BindingContext is ManualTestItem item)
            {
                item.TestState = result;
            }
        }
    }
}
