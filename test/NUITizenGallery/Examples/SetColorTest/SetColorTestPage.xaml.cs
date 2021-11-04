/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

using System;

namespace NUITizenGallery
{
    public partial class SetColorTestPage : ContentPage
    {
        private Random RandomGenerator = new Random();

        public SetColorTestPage()
        {
            InitializeComponent();

            ButtonColorName.Text = GetColorValues(ChangeColorButton.BackgroundColor);
            CheckBoxColorName.Text = GetColorValues(CheckBox2.BackgroundColor);
            ProgressBarColorName.Text = GetColorValues(ProgressBar.BackgroundColor);

            ChangeColorButton.Clicked += OnChangeColorClicked;
        }

        private Color GenerateColor(View component, TextLabel label)
        {
            component.BackgroundColor = new Color((float) RandomGenerator.NextDouble(),
                             (float) RandomGenerator.NextDouble(),
                             (float) RandomGenerator.NextDouble(),
                             (float) RandomGenerator.NextDouble());

            label.Text = GetColorValues(component.BackgroundColor);
            return component.BackgroundColor;
        }

        private void OnChangeColorClicked(object sender, ClickedEventArgs args)
        {
            GenerateColor(ChangeColorButton, ButtonColorName);
            Color tmp = GenerateColor(CheckBox1, CheckBoxColorName);
            CheckBox2.BackgroundColor = tmp;

            GenerateColor(ProgressBar, ProgressBarColorName);
            tmp = GenerateColor(RadioButton1, RadioColorName);
            RadioButton2.BackgroundColor = tmp;
        }

        private string GetColorValues(Color c)
        {
            return string.Format("R: {0} G: {1} B: {2} A: {3}", c.R, c.G, c.B, c.A);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                RemoveAllChildren(true);
            }

            base.Dispose(type);
        }

        private void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(this, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }

            int maxChild = (int)parent.ChildCount;
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }

                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }
    }

}
