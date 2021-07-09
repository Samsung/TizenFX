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
    public partial class StackLayoutTest6Page : View
    {
        public StackLayoutTest6Page()
        {
            InitializeComponent();
            this.Padding = new Extents(20, 20, 20, 20);
            paddingSlider.ValueChanged += OnPaddingSilderValueChanged;
            cellPaddingSlider.ValueChanged += OnCellPaddingilderValueChanged;
            changeOrientationButton.Clicked += OnOrientationButtonChanged;
        }

        private void OnOrientationButtonChanged(object sender, ClickedEventArgs e)
        {
            LinearLayout linearLayout = (layout.Layout as LinearLayout);

            var linearLayoutOrientation = linearLayout.LinearOrientation = linearLayout.LinearOrientation;


            if (linearLayoutOrientation == LinearLayout.Orientation.Vertical)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
                firstLabel.WidthSpecification = LayoutParamPolicies.WrapContent;
                firstLabel.HeightSpecification = LayoutParamPolicies.MatchParent;

                lastLabel.WidthSpecification = LayoutParamPolicies.WrapContent;
                lastLabel.HeightSpecification = LayoutParamPolicies.MatchParent;

                blueBox.WidthSpecification = 300;
                blueBox.HeightSpecification = LayoutParamPolicies.MatchParent;

                switchView.WidthSpecification = LayoutParamPolicies.WrapContent;
                switchView.HeightSpecification = LayoutParamPolicies.MatchParent;
            }
            else if (linearLayoutOrientation == LinearLayout.Orientation.Horizontal)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
                firstLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
                firstLabel.HeightSpecification = LayoutParamPolicies.WrapContent;

                lastLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
                lastLabel.HeightSpecification = LayoutParamPolicies.WrapContent;

                blueBox.HeightSpecification = 300;
                blueBox.WidthSpecification = LayoutParamPolicies.MatchParent;

                switchView.WidthSpecification = LayoutParamPolicies.MatchParent;
                switchView.HeightSpecification = LayoutParamPolicies.WrapContent;
            }
        }

        private void OnPaddingSilderValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            ushort margin = (ushort)e.CurrentValue;
            layout.Margin = new Extents(margin, margin, margin, margin);
        }

        private void OnCellPaddingilderValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            int cellPadding = (int)e.CurrentValue;
            (layout.Layout as LinearLayout).CellPadding = new Size2D(cellPadding, cellPadding);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                paddingSlider.ValueChanged -= OnPaddingSilderValueChanged;
                cellPaddingSlider.ValueChanged -= OnCellPaddingilderValueChanged;
                changeOrientationButton.Clicked -= OnOrientationButtonChanged;
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
