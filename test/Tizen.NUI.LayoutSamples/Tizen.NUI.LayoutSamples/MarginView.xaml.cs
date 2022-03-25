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
    public partial class MarginView : View, IObjectProperty<Extents>
    {
        private Text.InputFilter inputFilter;
        private ObjectView controlView = null;

        public MarginView()
        {
            InitializeComponent();

            inputFilter = new Text.InputFilter();
            inputFilter.Accepted = "[0-9]";
            marginStart.SetInputFilter(inputFilter);
            marginEnd.SetInputFilter(inputFilter);
            marginTop.SetInputFilter(inputFilter);
            marginBottom.SetInputFilter(inputFilter);
        }

        public Extents PropertyValue
        {
            get
            {
                return (controlView != null) ? controlView.Margin : new Extents(0, 0, 0, 0);
            }

            set
            {
                if (controlView == null) return;

                controlView.Margin = value;
            }
        }

        public void SetView(IObjectView view)
        {
            if (!(view is View)) return;

            if (controlView == view as ObjectView) return;

            controlView = view as ObjectView;

            // Margin
            marginStart.Text = controlView.Margin.Start.ToString();
            marginEnd.Text = controlView.Margin.End.ToString();
            marginTop.Text = controlView.Margin.Top.ToString();
            marginBottom.Text = controlView.Margin.Bottom.ToString();

            controlView.MarginChanged += (object sender, MarginChangedEventArgs args) =>
            {
                marginStart.Text = args.Margin.Start.ToString();
                marginEnd.Text = args.Margin.End.ToString();
                marginTop.Text = args.Margin.Top.ToString();
                marginBottom.Text = args.Margin.Bottom.ToString();

                controlView.Layout?.RequestLayout();
            };

            controlView.Layout?.RequestLayout();
        }

        private void MarginStartTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Margin = new Extents(changedValue, controlView.Margin.End, controlView.Margin.Top, controlView.Margin.Bottom);
                    controlView.Layout?.RequestLayout();
                }
            }
        }

        private void MarginEndTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Margin = new Extents(controlView.Margin.Start, changedValue, controlView.Margin.Top, controlView.Margin.Bottom);
                    controlView.Layout?.RequestLayout();
                }
            }
        }

        private void MarginTopTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Margin = new Extents(controlView.Margin.Start, controlView.Margin.End, changedValue, controlView.Margin.Bottom);
                    controlView.Layout?.RequestLayout();
                }
            }
        }

        private void MarginBottomTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                ushort changedValue;
                if (ushort.TryParse(args.TextField.Text, out changedValue))
                {
                    controlView.Margin = new Extents(controlView.Margin.Start, controlView.Margin.End, controlView.Margin.Top, changedValue);
                    controlView.Layout?.RequestLayout();
                }
            }
        }
    }
}
