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
    internal class DialogAndAlertDialogExample : ContentPage, IExample
    {
        private View rootContent;
        private Button buttonNoAction, buttonOneAction, buttonTwoAction, buttonNoTitle, buttonNoMessage;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public DialogAndAlertDialogExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Dialog AlertDialog Default Style",
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

            buttonNoAction = new Button
            {
                Name = "buttonNoAction",
                Text = "Show AlertDialog without button",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonNoAction);

            buttonNoAction.Clicked += (s, e) =>
            {
                DialogPage.ShowAlertDialog("Title", "Message", null);
            };

            buttonOneAction = new Button
            {
                Name = "buttonOneAction",
                Text = "Show AlertDialog with one button",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonOneAction);

            buttonOneAction.Clicked += (s, e) =>
            {
                var button = new Button()
                {
                    Text = "OK",
                };

                button.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                DialogPage.ShowAlertDialog("Title", "Message", button);
            };

            buttonTwoAction = new Button
            {
                Name = "buttonTwoAction",
                Text = "Show AlertDialog with two buttons",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonTwoAction);

            buttonTwoAction.Clicked += (s, e) =>
            {
                var button = new Button()
                {
                    Text = "Cancel",
                };

                button.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                var button2 = new Button()
                {
                    Text = "OK",
                };

                button2.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                DialogPage.ShowAlertDialog("Title", "Message", button, button2);
            };

            buttonNoTitle = new Button
            {
                Name = "buttonNoTitle",
                Text = "Show AlertDialog without title",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonNoTitle);

            buttonNoTitle.Clicked += (s, e) =>
            {
                var button = new Button()
                {
                    Text = "Cancel",
                };

                button.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                var button2 = new Button()
                {
                    Text = "OK",
                };

                button2.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                DialogPage.ShowAlertDialog(null, "Message", button, button2);
            };

            buttonNoMessage = new Button
            {
                Name = "buttonNoMessage",
                Text = "Show AlertDialog without message",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonNoMessage);

            buttonNoMessage.Clicked += (s, e) =>
            {
                var button = new Button()
                {
                    Text = "Cancel",
                };

                button.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                var button2 = new Button()
                {
                    Text = "OK",
                };

                button2.Clicked += (object sender, ClickedEventArgs args) =>
                {
                    Navigator?.Pop();
                };

                DialogPage.ShowAlertDialog("Title", null, button, button2);
            };

            Content = rootContent;
        }
    }
}
