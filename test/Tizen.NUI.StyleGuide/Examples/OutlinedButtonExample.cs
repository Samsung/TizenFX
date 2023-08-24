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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class OutlinedButtonExample : ContentPage, IExample
    {
        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public OutlinedButtonExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Outlined Style Button",
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

            // Outlined style Button examples.

            var enabledOutlinedButton = new Button("Tizen.NUI.Components.Button.Outlined")
            {
                Text = "Enabled"
            };
            enabledOutlinedButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Enabled Button Clicked\n");
            };
            rootContent.Add(enabledOutlinedButton);

            var disabledOutlinedButton = new Button("Tizen.NUI.Components.Button.Outlined")
            {
                Text = "Disabled",
                IsEnabled = false,
            };
            disabledOutlinedButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                // This event should not be recieved. Button is disabled.
                Log.Info(this.GetType().Name, "Disabled Button Clicked\n");

            };
            rootContent.Add(disabledOutlinedButton);

            var selectableOutlinedButton = new Button("Tizen.NUI.Components.Button.Outlined")
            {
                Text = "Unselected",
                IsSelectable = true,
            };
            selectableOutlinedButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Selected Button Clicked\n");
                if (obj is Button button)
                {
                    disabledOutlinedButton.IsEnabled = button.IsSelected;
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
            rootContent.Add(selectableOutlinedButton);
            Content = rootContent;
        }
    }
}
