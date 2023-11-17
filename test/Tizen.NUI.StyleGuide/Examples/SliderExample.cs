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
    internal class SliderExample : ContentPage, IExample
    {
        private View rootContent;
        private Slider slider, disabledSlider, completedSlider, verticalSlider;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public SliderExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Slider Default Style",
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

            // Slider examples.
            slider = new Slider()
            {
                MinValue = 0,
                MaxValue = 100,
                WidthSpecification = 300,
            };
            rootContent.Add(slider);

            disabledSlider = new Slider()
            {
                MinValue = 0,
                MaxValue = 100,
                IsEnabled = false,
                WidthSpecification = 300,
            };
            rootContent.Add(disabledSlider);

            completedSlider = new Slider()
            {
                MinValue = 0,
                MaxValue = 100,
                CurrentValue = 100,
                WidthSpecification = 300,
                IsValueShown = true,
            };
            rootContent.Add(completedSlider);
            completedSlider.ValueChanged += OnValueChanged;

            verticalSlider = new Slider()
            {
                MinValue = 0,
                MaxValue = 100,
                CurrentValue = 100,
                Direction = Slider.DirectionType.Vertical,
                HeightSpecification = 200,
            };
            rootContent.Add(verticalSlider);

            Content = rootContent;
        }

        private void OnValueChanged(object sender, SliderValueChangedEventArgs args)
        {
            Slider source = sender as Slider;
            if (source != null)
            {
                source.ValueIndicatorText = args.CurrentValue.ToString();
            }
        }
    }
}
