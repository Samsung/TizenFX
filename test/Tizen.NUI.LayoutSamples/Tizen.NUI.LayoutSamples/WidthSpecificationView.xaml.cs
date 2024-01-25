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
    public partial class WidthSpecificationView : View, IObjectProperty<int>
    {
        private RadioButtonGroup widthSpecGroup;
        private Text.InputFilter inputFilter;
        private ObjectView controlView = null;

        public WidthSpecificationView()
        {
            InitializeComponent();

            widthSpecGroup = new RadioButtonGroup();
            widthSpecGroup.Add(widthSpecMatchParent);
            widthSpecGroup.Add(widthSpecWrapContent);
            widthSpecGroup.Add(widthSpecValue);
            widthSpecGroup.EnableMultiSelection = false;
            widthSpecWrapContent.IsSelected = true;
            // FIXME: TextField does not support IsEnabled now.
            widthSpecValueField.EnableEditing = false;

            inputFilter = new Text.InputFilter();
            inputFilter.Accepted = "[0-9]";
            widthSpecValueField.SetInputFilter(inputFilter);
        }

        public int PropertyValue
        {
            get
            {
                return (controlView != null) ? controlView.WidthSpecification : LayoutParamPolicies.WrapContent;
            }

            set
            {
                if (controlView == null) return;

                controlView.WidthSpecification = value;
            }
        }

        public void SetView(IObjectView view)
        {
            if (!(view is View)) return;

            if (controlView == view as ObjectView) return;

            controlView = view as ObjectView;

            // WidthSpecification
            if (controlView.WidthSpecification == LayoutParamPolicies.MatchParent)
            {
                widthSpecMatchParent.IsSelected = true;
            }
            else if (controlView.WidthSpecification == LayoutParamPolicies.WrapContent)
            {
                widthSpecWrapContent.IsSelected = true;
            }
            else
            {
                widthSpecValueField.Text = controlView.WidthSpecification.ToString();
                widthSpecValue.IsSelected = true;
            }

            controlView.WidthSpecificationChanged += (object sender, WidthSpecificationChangedEventArgs args) =>
            {
                if (args.WidthSpecification == LayoutParamPolicies.MatchParent)
                {
                    widthSpecMatchParent.IsSelected = true;
                }
                else if (args.WidthSpecification == LayoutParamPolicies.WrapContent)
                {
                    widthSpecWrapContent.IsSelected = true;
                }
                else
                {
                    widthSpecValueField.Text = controlView.WidthSpecification.ToString();
                    widthSpecValue.IsSelected = true;
                }

                (controlView.Layout)?.RequestLayout();
            };

            (controlView.Layout)?.RequestLayout();
        }

        private void WidthSpecMatchParentSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                widthSpecValueField.Text = LayoutParamPolicies.MatchParent.ToString();
                if (controlView != null)
                {
                    controlView.WidthSpecification = LayoutParamPolicies.MatchParent;
                }
            }
        }

        private void WidthSpecWrapContentSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                widthSpecValueField.Text = LayoutParamPolicies.WrapContent.ToString();
                if (controlView != null)
                {
                    controlView.WidthSpecification = LayoutParamPolicies.WrapContent;
                }
            }
        }

        private void WidthSpecValueSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                widthSpecValueField.EnableEditing = true;
                if (controlView != null)
                {
                    int changedValue;
                    if (int.TryParse(widthSpecValueField.Text, out changedValue))
                    {
                        if (controlView.WidthSpecification != changedValue)
                        {
                            controlView.WidthSpecification = changedValue;
                            controlView.Layout?.RequestLayout();
                        }
                    }
                }
            }
            else
            {
                widthSpecValueField.EnableEditing = false;
            }
        }

        private void WidthSpecValueTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                int changedValue;
                if (int.TryParse(widthSpecValueField.Text, out changedValue))
                {
                    controlView.WidthSpecification = changedValue;
                    controlView.Layout?.RequestLayout();
                }
            }
        }
    }
}
