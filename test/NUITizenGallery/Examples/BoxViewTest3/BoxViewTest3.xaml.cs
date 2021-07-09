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
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class BoxViewTest3 : View
    {
        public BoxViewTest3()
        {
            InitializeComponent();
            Subscribe();
            ApplyColor();
        }

        private void Subscribe()
        {
            red.ValueChanged += OnSliderValueChanged;
            green.ValueChanged += OnSliderValueChanged;
            blue.ValueChanged += OnSliderValueChanged;
            alpha.ValueChanged += OnSliderValueChanged;
        }

        private void Unsubscribe()
        {
            red.ValueChanged -= OnSliderValueChanged;
            green.ValueChanged -= OnSliderValueChanged;
            blue.ValueChanged -= OnSliderValueChanged;
            alpha.ValueChanged -= OnSliderValueChanged;
        }

        private void OnSliderValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            ApplyColor();
        }

        private void ApplyColor()
        {
            float r = red.CurrentValue / 255f;
            float g = green.CurrentValue / 255f;
            float b = blue.CurrentValue / 255f;
            float a = alpha.CurrentValue / 255f;

            colorBox.BackgroundColor = new Color(r, g, b, a);
            preColorBox.BackgroundColor = new Color(r * a, g * a, b * a, a);

            output.Text = String.Format("R={0:000}, G={1:000}, B={2:000}, A={3:000}", r * 255f, g * 255f, b * 255f, a * 255f);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Unsubscribe();
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
