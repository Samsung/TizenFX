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
    public partial class HorizontalAlignmentView : View, ILayoutProperty<HorizontalAlignment>
    {
        private RadioButtonGroup hAlignGroup;
        private RadioButtonGroup vAlignGroup;
        private ObjectLinearLayout linearLayout = null;

        public HorizontalAlignmentView()
        {
            InitializeComponent();

            hAlignGroup = new RadioButtonGroup();
            hAlignGroup.Add(hAlignBegin);
            hAlignGroup.Add(hAlignCenter);
            hAlignGroup.Add(hAlignEnd);
            hAlignGroup.EnableMultiSelection = false;
            hAlignBegin.IsSelected = true;
        }

        public HorizontalAlignment PropertyValue
        {
            get
            {
                return (linearLayout != null) ? linearLayout.HorizontalAlignment : HorizontalAlignment.Begin;
            }

            set
            {
                if (linearLayout == null) return;
                
                linearLayout.HorizontalAlignment = value;
            }
        }

        public void SetLayout(IObjectLayout layout)
        {
            if (!(layout is LinearLayout)) return;

            if (linearLayout == layout as ObjectLinearLayout) return;

            linearLayout = layout as ObjectLinearLayout;

            // HorizontalAlignment
            if (linearLayout.HorizontalAlignment == HorizontalAlignment.Begin)
            {
                hAlignBegin.IsSelected = true;
            }
            else if (linearLayout.HorizontalAlignment == HorizontalAlignment.Center)
            {
                hAlignCenter.IsSelected = true;
            }
            else
            {
                hAlignEnd.IsSelected = true;
            }

            linearLayout.HorizontalAlignmentChanged += (object sender, HorizontalAlignmentChangedEventArgs args) =>
            {
                if (args.HorizontalAlignment == HorizontalAlignment.Begin)
                {
                    hAlignBegin.IsSelected = true;
                }
                else if (args.HorizontalAlignment == HorizontalAlignment.Center)
                {
                    hAlignCenter.IsSelected = true;
                }
                else
                {
                    hAlignEnd.IsSelected = true;
                }

                linearLayout.RequestLayout();
            };

            linearLayout.RequestLayout();
        }

        private void HAlignBeginSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.HorizontalAlignment = HorizontalAlignment.Begin;
                    linearLayout.RequestLayout();
                }
            }
        }

        private void HAlignCenterSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.HorizontalAlignment = HorizontalAlignment.Center;
                    linearLayout.RequestLayout();
                }
            }
        }

        private void HAlignEndSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                if (linearLayout != null)
                {
                    linearLayout.HorizontalAlignment = HorizontalAlignment.End;
                    linearLayout.RequestLayout();
                }
            }
        }
    }
}
