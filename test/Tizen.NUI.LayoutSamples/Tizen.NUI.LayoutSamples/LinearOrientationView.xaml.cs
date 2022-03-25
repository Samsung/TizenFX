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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.LayoutSamples
{
    public partial class LinearOrientationView : View, ILayoutProperty<LinearLayout.Orientation>
    {
        private RadioButtonGroup linearOrientGroup;
        private ObjectLinearLayout linearLayout = null;

        public LinearOrientationView()
        {
            InitializeComponent();

            linearOrientGroup = new RadioButtonGroup();
            linearOrientGroup.Add(linearOrientH);
            linearOrientGroup.Add(linearOrientV);
            linearOrientGroup.EnableMultiSelection = false;
            linearOrientH.IsSelected = true;
        }

        public LinearLayout.Orientation PropertyValue
        {
            get
            {
                return (linearLayout != null) ? linearLayout.LinearOrientation : LinearLayout.Orientation.Horizontal;
            }

            set
            {
                if (linearLayout == null) return;

                linearLayout.LinearOrientation = value;
            }
        }

        public void SetLayout(IObjectLayout layout)
        {
            if (!(layout is LinearLayout)) return;

            if (linearLayout == layout as ObjectLinearLayout) return;

            linearLayout = layout as ObjectLinearLayout;

            // LinearOrientation
            if (linearLayout.LinearOrientation == LinearLayout.Orientation.Horizontal)
            {
                linearOrientH.IsSelected = true;
            }
            else
            {
                linearOrientV.IsSelected = true;
            }

            linearLayout.LinearOrientationChanged += (object sender, LinearOrientationChangedEventArgs args) =>
            {
                if (args.LinearOrientation == LinearLayout.Orientation.Horizontal)
                {
                    linearOrientH.IsSelected = true;
                }
                else
                {
                    linearOrientV.IsSelected = true;
                }

                linearLayout.RequestLayout();
            };

            linearLayout.RequestLayout();
        }

        private void LinearOrientHSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
                    linearLayout.RequestLayout();
                }
            }
        }

        private void LinearOrientVSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
                    linearLayout.RequestLayout();
                }
            }
        }
    }
}
