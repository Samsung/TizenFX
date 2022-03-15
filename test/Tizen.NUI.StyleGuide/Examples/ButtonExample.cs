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
    internal class ButtonExample : ContentPage, IExample
    {
        private Window window;
        public void Activate()
        {
           Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()\n");
        }
        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()\n");
            window = null;
        }

        /// Modify this method for adding other examples.
        public ButtonExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Button Default Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            var rootContent = new View()
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

            // Button style examples.

            var enabledButton = new Button()
            {
                Text = "Enabled"
            };
            enabledButton.EnableFocus();
            enabledButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Enabled Button Clicked\n");
            };
            rootContent.Add(enabledButton);

            var disabledButton = new Button()
            {
                Text = "Disabled",
                IsEnabled = false,
            };
            disabledButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                // This event should not be recieved. button is disabled.
                Log.Info(this.GetType().Name, "Disabled Button Clicked\n");

            };
            rootContent.Add(disabledButton);

            var selectableButton = new Button()
            {
                Text = "Unselected",
                IsSelectable = true,
            };
            selectableButton.EnableFocus();
            selectableButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Selected Button Clicked\n");
                if (obj is Button button)
                {
                   if (button.IsSelected)
                    {
                        button.Text = "Selected";
                    }
                    else
                    {
                        button.Text = "Unselected";
                    }
                }
            };
            rootContent.Add(selectableButton);
            Content = rootContent;
        }
    }
}
