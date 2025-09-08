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

using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NUITizenGallery
{
    public partial class PickerTest1Page : ContentPage
    {
        String[] textValue = new string[] { "Black", "Blue", "Green", "Maroon", "Pink", "Teal", "Yellow"};
        Color[] colorValue = new Color[] {Color.Black, Color.Blue, Color.Green, Color.Maroon, Color.Pink, Color.Teal, Color.Yellow};

        private void onValueChanged(object sender, ValueChangedEventArgs e)
        {
            text1.Text = textValue[e.Value];
            text1.TextColor = colorValue[e.Value];
            rect1.BackgroundColor = colorValue[e.Value];
            Console.WriteLine("Value is " + e.Value);
        }

        public PickerTest1Page()
        {
            InitializeComponent();
            picker1.DisplayedValues = new ReadOnlyCollection<string>(textValue);
            picker1.ValueChanged += onValueChanged;
        }
    }
}
