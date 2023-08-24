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
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.LayoutSamples
{
    public enum LayoutType
    {
        LinearLayout = 0,
    }

    public class LayoutTypeChangedEventArgs : EventArgs
    {
        public LayoutTypeChangedEventArgs(LayoutType type)
        {
            LayoutType = type;
        }

        public LayoutType LayoutType { get; set; }
    }

    public partial class LayoutTypeView : View
    {
        private RadioButtonGroup layoutTypeGroup;
        private LayoutType layoutType = LayoutType.LinearLayout;

        public LayoutTypeView()
        {
            InitializeComponent();

            layoutTypeGroup = new RadioButtonGroup();
            layoutTypeGroup.Add(layoutTypeLinear);
            layoutTypeGroup.EnableMultiSelection = false;
            layoutTypeLinear.IsSelected = true;
        }

        public event EventHandler<LayoutTypeChangedEventArgs> LayoutTypeChanged;

        public LayoutType LayoutType
        {
            get
            {
                return layoutType;
            }

            set
            {
                if (layoutType == value) return;
                layoutType = value;

                if (layoutType == LayoutType.LinearLayout)
                {
                    if (layoutTypeLinear.IsSelected == false)
                    {
                        layoutTypeLinear.IsSelected = true;
                    }
                }
                else
                {
                    // TODO: Add more layout types
                }

                LayoutTypeChanged?.Invoke(this, new LayoutTypeChangedEventArgs(layoutType));
            }
        }

        private void LinearSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                LayoutType = LayoutType.LinearLayout;
            }
        }
    }
}
