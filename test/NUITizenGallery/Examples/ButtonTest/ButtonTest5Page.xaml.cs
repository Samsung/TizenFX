/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest5Page : ContentPage
    {
        bool opacityToggle = false;
        public ButtonTest5Page()
        {
            InitializeComponent();

            slider1.ValueChanged += (o, e) =>
            {
                text1.Text = "Button Size: " + slider1.CurrentValue;
                button1.SizeHeight = slider1.CurrentValue;
                button2.SizeHeight = slider1.CurrentValue;
            };

            slider2.ValueChanged += (o, e) =>
            {
                text2.Text = "Button Font Size: " + slider2.CurrentValue;
                button1.PointSize = slider2.CurrentValue;
                button2.PointSize = slider2.CurrentValue;
            };

            slider3.ValueChanged += (o, e) =>
            {
                text3.Text = "Button Opacity: " + slider3.CurrentValue;
                button1.Opacity = slider3.CurrentValue;
                button2.Opacity = slider3.CurrentValue;
            };

            button1.Clicked += (o, e) =>
            {
                opacityToggle = !opacityToggle;
                if (opacityToggle)
                {
                    slider3.CurrentValue = 0.5f;
                }
                else
                {
                    slider3.CurrentValue = 1.0f;
                }
                text3.Text = "Button Opacity: " + slider3.CurrentValue;
                button1.Opacity = slider3.CurrentValue;
                button2.Opacity = slider3.CurrentValue;
            };

        }
    }
}