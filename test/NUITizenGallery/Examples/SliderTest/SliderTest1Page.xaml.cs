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
    public partial class SliderTest1Page : ContentPage
    {
        public SliderTest1Page()
        {
            InitializeComponent();
            slider1.ValueChanged += (o, e) =>
            {
                text1.Text = "slider value: " + slider1.CurrentValue;
            };

            button1.Clicked += (o, e) =>
            {
                if (slider1.CurrentValue + 10 > slider1.MaxValue) return;
                slider1.CurrentValue += 10;
                text1.Text = "slider value: " + slider1.CurrentValue;
            };

            button2.Clicked += (o, e) =>
            {
                if (slider1.CurrentValue - 10 < slider1.MinValue) return;
                slider1.CurrentValue -= 10;
                text1.Text = "slider value: " + slider1.CurrentValue;
            };
        }
    }
}