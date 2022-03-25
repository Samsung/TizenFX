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
    public partial class VerticalAlignmentView : View, ILayoutProperty<VerticalAlignment>
    {
        private RadioButtonGroup vAlignGroup;
        private ObjectLinearLayout linearLayout = null;

        public VerticalAlignmentView()
        {
            InitializeComponent();

            vAlignGroup = new RadioButtonGroup();
            vAlignGroup.Add(vAlignTop);
            vAlignGroup.Add(vAlignCenter);
            vAlignGroup.Add(vAlignBottom);
            vAlignGroup.EnableMultiSelection = false;
            vAlignTop.IsSelected = true;
        }

        public VerticalAlignment PropertyValue
        {
            get
            {
                return (linearLayout != null) ? linearLayout.VerticalAlignment : VerticalAlignment.Top;
            }

            set
            {
                if (linearLayout == null) return;

                linearLayout.VerticalAlignment = value;
            }
        }

        public void SetLayout(IObjectLayout layout)
        {
            if (!(layout is LinearLayout)) return;

            if (linearLayout == layout as ObjectLinearLayout) return;

            linearLayout = layout as ObjectLinearLayout;

            // VerticalAlignment
            if (linearLayout.VerticalAlignment == VerticalAlignment.Top)
            {
                vAlignTop.IsSelected = true;
            }
            else if (linearLayout.VerticalAlignment == VerticalAlignment.Center)
            {
                vAlignCenter.IsSelected = true;
            }
            else
            {
                vAlignBottom.IsSelected = true;
            }

            linearLayout.VerticalAlignmentChanged += (object sender, VerticalAlignmentChangedEventArgs args) =>
            {
                if (args.VerticalAlignment == VerticalAlignment.Top)
                {
                    vAlignTop.IsSelected = true;
                }
                else if (args.VerticalAlignment == VerticalAlignment.Center)
                {
                    vAlignCenter.IsSelected = true;
                }
                else
                {
                    vAlignBottom.IsSelected = true;
                }

                linearLayout.RequestLayout();
            };

            linearLayout.RequestLayout();
        }

        private void VAlignTopSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.VerticalAlignment = VerticalAlignment.Top;
                    linearLayout.RequestLayout();
                }
            }
        }

        private void VAlignCenterSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.VerticalAlignment = VerticalAlignment.Center;
                    linearLayout.RequestLayout();
                }
            }
        }

        private void VAlignBottomSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.VerticalAlignment = VerticalAlignment.Bottom;
                    linearLayout.RequestLayout();
                }
            }
        }
    }
}
