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
    public partial class PaddingView : View, IObjectProperty<Extents>
    {
        private Text.InputFilter inputFilter;
        private ObjectView controlView = null;

        public PaddingView()
        {
            InitializeComponent();

            inputFilter = new Text.InputFilter();
            inputFilter.Accepted = "[0-9]";
            paddingStart.SetInputFilter(inputFilter);
            paddingEnd.SetInputFilter(inputFilter);
            paddingTop.SetInputFilter(inputFilter);
            paddingBottom.SetInputFilter(inputFilter);
        }

        public Extents PropertyValue
        {
            get
            {
                return (controlView != null) ? controlView.Padding : new Extents(0, 0, 0, 0);
            }

            set
            {
                if (controlView == null) return;

                controlView.Padding = value;
            }
        }

        public void SetView(IObjectView view)
        {
            if (!(view is View)) return;

            if (controlView == view as ObjectView) return;

            controlView = view as ObjectView;

            // Padding
            paddingStart.Text = controlView.Padding.Start.ToString();
            paddingEnd.Text = controlView.Padding.End.ToString();
            paddingTop.Text = controlView.Padding.Top.ToString();
            paddingBottom.Text = controlView.Padding.Bottom.ToString();

            controlView.PaddingChanged += (object sender, PaddingChangedEventArgs args) =>
            {
                paddingStart.Text = args.Padding.Start.ToString();
                paddingEnd.Text = args.Padding.End.ToString();
                paddingTop.Text = args.Padding.Top.ToString();
                paddingBottom.Text = args.Padding.Bottom.ToString();

                controlView.Layout?.RequestLayout();
            };

            controlView.Layout?.RequestLayout();
        }

        private void PaddingStartTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Padding = new Extents(changedValue, controlView.Padding.End, controlView.Padding.Top, controlView.Padding.Bottom);
                    controlView.Layout?.RequestLayout();
                }
            }
        }

        private void PaddingEndTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Padding = new Extents(controlView.Padding.Start, changedValue, controlView.Padding.Top, controlView.Padding.Bottom);
                    controlView.Layout?.RequestLayout();
                }
            }
        }

        private void PaddingTopTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Padding = new Extents(controlView.Padding.Start, controlView.Padding.End, changedValue, controlView.Padding.Bottom);
                    controlView.Layout?.RequestLayout();
                }
            }
        }

        private void PaddingBottomTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Padding = new Extents(controlView.Padding.Start, controlView.Padding.End, controlView.Padding.Top, changedValue);
                    controlView.Layout?.RequestLayout();
                }
            }
        }
    }
}
