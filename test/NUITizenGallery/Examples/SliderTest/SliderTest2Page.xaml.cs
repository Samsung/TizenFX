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
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class SliderTest2Page : ContentPage
    {
        float saveHeight = 0;
        public SliderTest2Page()
        {
            InitializeComponent();
            button1.Clicked += (o, e) =>
            {
                if (slider1.Direction == Slider.DirectionType.Vertical)
                {
                    slider1.Direction = Slider.DirectionType.Horizontal;
                    slider1.SizeHeight = saveHeight;
                } 
                else
                {
                    slider1.Direction = Slider.DirectionType.Vertical;
                    saveHeight = slider1.SizeHeight;
                    slider1.SizeHeight = 300;
                }

            };

            slider1.ValueChanged += (o, e) =>
            {
                text1.Text = "slider value: " + slider1.CurrentValue;
            };
        }
    }
}