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
                Title = "OutlinedButton Default Style",
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

            // OutlinedButton style examples.

            var enabledOutlinedButton = new OutlinedButton()
            {
                Text = "Enabled"
            };
            enabledOutlinedButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Enabled OutlinedButton Clicked\n");
            };
            rootContent.Add(enabledOutlinedButton);

            var disabledOutlinedButton = new OutlinedButton()
            {
                Text = "Disabled",
                IsEnabled = false,
            };
            disabledOutlinedButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                // This event should not be recieved. OutlinedButton is disabled.
                Log.Info(this.GetType().Name, "Disabled OutlinedButton Clicked\n");

            };
            rootContent.Add(disabledOutlinedButton);

            var selectableOutlinedButton = new OutlinedButton()
            {
                Text = "Unselected",
                IsSelectable = true,
            };
            selectableOutlinedButton.Clicked += (object obj, ClickedEventArgs ev) =>
            {
                Log.Info(this.GetType().Name, "Selected OutlinedButton Clicked\n");
                if (obj is OutlinedButton OutlinedButton)
                {
                    disabledOutlinedButton.IsEnabled = OutlinedButton.IsSelected;
                    if (OutlinedButton.IsSelected)
                    {
                        OutlinedButton.Text = "Selected";
                    }
                    else
                    {
                        OutlinedButton.Text = "Unselected";
                    }
                }
            };
            rootContent.Add(selectableOutlinedButton);
            Content = rootContent;
        }
    }
}
