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
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Manual.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Components.Button manual test")]
    public class TSButton
    {

        View testView;

        [SetUp]
        public void Init()
        {
            Console.WriteLine("Button Init!");
            ManualTest test = ManualTest.GetInstance();
            ManualTestList list = ManualTestList.GetInstance();
            testView = test.CurrentPage.TestContent;
            testView.HeightSpecification = 300;
        }

        [TearDown]
        public void Destroy()
        {
            Console.WriteLine("Button Destroy!");
        }


        public void OnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button OnClicked!");
            //ManualTest.Confirm();
        }

        public void OnSelectedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Button OnSelectionChanged!");

            if (sender is Button button)
            {
                button.Text = (button.IsSelected ? "Selected" : "Unselected");
            }
            //ManualTest.Confirm();
        }

        [Test]
        [Category("P1")]
        [Description("Test: Click. Check whether the event will be triggered when user click the button")]
        [Property("SPEC", "Tizen.NUI.Components.Button.ClickEvent E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "SangHyeon Lee, sh10233.lee@samsung.com")]
        [Precondition(1, "If test on TV, prepare mouse and connect to TV.")]
        [Step(1, "Click run TC")]
        [Step(2, "Click(Touch) the button.")]
        [Step(3, "TC will pass after touch or click.")]
        [Postcondition(1, "NA")]
        public async Task ClickedCallBackTest()
        {
            Console.WriteLine("ClickedCallBackTest begin!");
            var button = new Button()
            {
                Text = "Click Me!",
            };
            button.Clicked += OnClicked;
            testView.Add(button);

            //await ManualTest.WaitForConfirm();
        }


        [Test]
        [Category("P1")]
        [Description("Test: Select. Check whether the event will be triggered when user click the button")]
        [Property("SPEC", "Tizen.NUI.Components.SelectButton.SelectedChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "SangHyeon Lee, sh10233.lee@samsung.com")]
        [Precondition(1, "If test on TV, prepare mouse and connect to TV.")]
        [Step(1, "Click run TC")]
        [Step(2, "Click(Touch) the button.")]
        [Step(3, "TC will pass after touch or click.")]
        [Postcondition(1, "NA")]
        public async Task SelectedChangedCallBackTest()
        {
            Console.WriteLine("SelectedChangedCallBackTest begin!");
            var button = new SelectButton()
            {
                Text = "Unselected",
            };
            button.SelectedChanged += OnSelectedChanged;
            testView.Add(button);

            //await ManualTest.WaitForConfirm();
        }
    }
}
