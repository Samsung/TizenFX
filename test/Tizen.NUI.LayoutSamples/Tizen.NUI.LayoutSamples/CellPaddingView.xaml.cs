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

namespace Tizen.NUI.LayoutSamples
{
    public partial class CellPaddingView : View, ILayoutProperty<Size2D>
    {
        private Text.InputFilter inputFilter;
        private ObjectLinearLayout linearLayout = null;

        public CellPaddingView()
        {
            InitializeComponent();

            inputFilter = new Text.InputFilter();
            inputFilter.Accepted = "[0-9]";
            cellPaddingW.SetInputFilter(inputFilter);
            cellPaddingH.SetInputFilter(inputFilter);
        }

        public Size2D PropertyValue
        {
            get
            {
                return (linearLayout != null) ? linearLayout.CellPadding : new Size2D(0, 0);
            }

            set
            {
                if (linearLayout == null) return;

                linearLayout.CellPadding = value;
            }
        }

        public void SetLayout(IObjectLayout layout)
        {
            if (!(layout is LinearLayout)) return;

            if (linearLayout == layout as ObjectLinearLayout) return;

            linearLayout = layout as ObjectLinearLayout;

            // CellPadding
            cellPaddingW.Text = linearLayout.CellPadding.Width.ToString();
            cellPaddingH.Text = linearLayout.CellPadding.Height.ToString();

            linearLayout.CellPaddingChanged += (object sender, CellPaddingChangedEventArgs args) =>
            {
                cellPaddingW.Text = args.CellPadding.Width.ToString();
                cellPaddingH.Text = args.CellPadding.Height.ToString();

                linearLayout.RequestLayout();
            };

            linearLayout.RequestLayout();
        }

        private void CellPaddingWTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (linearLayout != null)
            {
                int changedValue;
                if (int.TryParse(args.TextField.Text, out changedValue))
                {
                    linearLayout.CellPadding = new Size2D(changedValue, linearLayout.CellPadding.Height);
                    linearLayout.RequestLayout();
                }
            }
        }

        private void CellPaddingHTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (linearLayout != null)
            {
                int changedValue;
                if (int.TryParse(args.TextField.Text, out changedValue))
                {
                    linearLayout.CellPadding = new Size2D(linearLayout.CellPadding.Width, changedValue);
                    linearLayout.RequestLayout();
                }
            }
        }
    }
}
