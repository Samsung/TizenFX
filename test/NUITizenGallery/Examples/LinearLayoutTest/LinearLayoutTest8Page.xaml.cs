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

namespace NUITizenGallery
{
    public partial class LinearLayoutTest8Page : ContentPage
    {
        public LinearLayoutTest8Page()
        {
            InitializeComponent();
            this.Padding = new Extents(20, 20, 20, 20);
            sliderPadding.ValueChanged += OnPaddingSliderChanged;
            sliderCellPadding.ValueChanged += OnCellPaddingSilderChanged;
            sliderMargin.ValueChanged += OnMarginSliderChanged;
            buttonOrientation.Clicked += OnButtonOrientationClicked;
            buttonReset.Clicked += OnResetButtonClikced;

        }

        private void OnPaddingSliderChanged(object sender, SliderValueChangedEventArgs e)
        {
            ushort padding = (ushort)e.CurrentValue;
            layout.Padding = new Extents(padding, padding, padding, padding);
        }

        private void OnCellPaddingSilderChanged(object sender, SliderValueChangedEventArgs e)
        {
            (layout.Layout as LinearLayout).CellPadding = new Size2D((int)e.CurrentValue, (int)e.CurrentValue);
        }

        private void OnMarginSliderChanged(object sender, SliderValueChangedEventArgs e)
        {
            ushort margin = (ushort)e.CurrentValue;
            layout.Margin = new Extents(margin, margin, margin, margin);
        }

        private void OnButtonOrientationClicked(object sender, ClickedEventArgs e)
        {
            LinearLayout linearLayout = (layout.Layout as LinearLayout);

            if (linearLayout.LinearOrientation == LinearLayout.Orientation.Horizontal)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
                redBox.WidthSpecification = LayoutParamPolicies.MatchParent;
                greenBox.WidthSpecification = LayoutParamPolicies.MatchParent;
                blueBox.WidthSpecification = LayoutParamPolicies.MatchParent;
                redBox.HeightSpecification = 80;
                greenBox.HeightSpecification = 80;
                blueBox.HeightSpecification = 80;
            }
            else
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
                redBox.WidthSpecification = 80;
                greenBox.WidthSpecification = 80;
                blueBox.WidthSpecification = 80;
            }
        }

        private void OnResetButtonClikced(object sender, ClickedEventArgs e)
        {
            layout.Padding = new Extents(0, 0, 0, 0);
            layout.Margin = new Extents(0, 0, 0, 0);
            (layout.Layout as LinearLayout).CellPadding = new Size2D(0,0);

            sliderPadding.CurrentValue = 0.0f;
            sliderCellPadding.CurrentValue = 0.0f;
            sliderMargin.CurrentValue = 0.0f;

        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                sliderPadding.ValueChanged -= OnPaddingSliderChanged;
                sliderCellPadding.ValueChanged -= OnCellPaddingSilderChanged;
                sliderMargin.ValueChanged -= OnMarginSliderChanged;
                buttonOrientation.Clicked -= OnButtonOrientationClicked;
                buttonReset.Clicked -= OnResetButtonClikced;
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
