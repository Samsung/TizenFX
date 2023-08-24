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
    internal class DatePickerExample : ContentPage, IExample
    {
        private View rootContent;
        private DatePicker datePicker;
        private TextLabel label;
        private Button button;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public DatePickerExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "DatePicker Default Style",
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

            // Picker style examples.
            datePicker = new DatePicker()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Date = DateTime.Now
            };
            rootContent.Add(datePicker);


            label = new TextLabel
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = $"Date: {datePicker.Date.ToString()}"
            };
            rootContent.Add(label);

            var toggle = new Switch()
            {
                Text = "Disable Switch",
            };
            toggle.SelectedChanged += (object obj, SelectedChangedEventArgs ev) =>
            {
                datePicker.IsEnabled = !(ev.IsSelected);
                Console.WriteLine($"Picker is {datePicker.IsEnabled}");
            };
            rootContent.Add(toggle);

            button = new Tizen.NUI.Components.Button
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = "set date"
            };
            rootContent.Add(button);

            button.Clicked += (s, e) =>
            {
                label.Text = $"Date: {datePicker.Date.ToString()}";
            };

            Content = rootContent;
        }
    }
}
