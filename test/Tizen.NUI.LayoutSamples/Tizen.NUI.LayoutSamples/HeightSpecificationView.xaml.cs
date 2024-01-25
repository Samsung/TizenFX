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
    public partial class HeightSpecificationView : View, IObjectProperty<int>
    {
        private RadioButtonGroup heightSpecGroup;
        private Text.InputFilter inputFilter;
        private ObjectView controlView = null;

        public HeightSpecificationView()
        {
            InitializeComponent();

            heightSpecGroup = new RadioButtonGroup();
            heightSpecGroup.Add(heightSpecMatchParent);
            heightSpecGroup.Add(heightSpecWrapContent);
            heightSpecGroup.Add(heightSpecValue);
            heightSpecGroup.EnableMultiSelection = false;
            heightSpecWrapContent.IsSelected = true;
            // FIXME: TextField does not support IsEnabled now.
            heightSpecValueField.EnableEditing = false;

            inputFilter = new Text.InputFilter();
            inputFilter.Accepted = "[0-9]";
            heightSpecValueField.SetInputFilter(inputFilter);
        }

        public int PropertyValue
        {
            get
            {
                return (controlView != null) ? controlView.HeightSpecification : LayoutParamPolicies.WrapContent;
            }

            set
            {
                if (controlView == null) return;

                controlView.HeightSpecification = value;
            }
        }

        public void SetView(IObjectView view)
        {
            if (!(view is View)) return;

            if (controlView == view as ObjectView) return;

            controlView = view as ObjectView;

            // HeightSpecification
            if (controlView.HeightSpecification == LayoutParamPolicies.MatchParent)
            {
                heightSpecMatchParent.IsSelected = true;
            }
            else if (controlView.HeightSpecification == LayoutParamPolicies.WrapContent)
            {
                heightSpecWrapContent.IsSelected = true;
            }
            else
            {
                heightSpecValueField.Text = controlView.HeightSpecification.ToString();
                heightSpecValue.IsSelected = true;
            }

            controlView.HeightSpecificationChanged += (object sender, HeightSpecificationChangedEventArgs args) =>
            {
                if (args.HeightSpecification == LayoutParamPolicies.MatchParent)
                {
                    heightSpecMatchParent.IsSelected = true;
                }
                else if (args.HeightSpecification == LayoutParamPolicies.WrapContent)
                {
                    heightSpecWrapContent.IsSelected = true;
                }
                else
                {
                    heightSpecValueField.Text = controlView.HeightSpecification.ToString();
                    heightSpecValue.IsSelected = true;
                }

                (controlView.Layout)?.RequestLayout();
            };

            (controlView.Layout)?.RequestLayout();
        }

        private void HeightSpecMatchParentSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                heightSpecValueField.Text = LayoutParamPolicies.MatchParent.ToString();
                if (controlView != null)
                {
                    controlView.HeightSpecification = LayoutParamPolicies.MatchParent;
                }
            }
        }

        private void HeightSpecWrapContentSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                heightSpecValueField.Text = LayoutParamPolicies.WrapContent.ToString();
                if (controlView != null)
                {
                    controlView.HeightSpecification = LayoutParamPolicies.WrapContent;
                }
            }
        }

        private void HeightSpecValueSelectedChanged(object sender, SelectedChangedEventArgs args)
        {
            if (args.IsSelected)
            {
                heightSpecValueField.EnableEditing = true;
                if (controlView != null)
                {
                    int changedValue;
                    if (int.TryParse(heightSpecValueField.Text, out changedValue))
                    {
                        if (controlView.HeightSpecification != changedValue)
                        {
                            controlView.HeightSpecification = changedValue;
                            controlView.Layout?.RequestLayout();
                        }
                    }
                }
            }
            else
            {
                heightSpecValueField.EnableEditing = false;
            }
        }

        private void HeightSpecValueTextChanged(object sender, TextField.TextChangedEventArgs args)
        {
            if (controlView != null)
            {
                int changedValue;
                if (int.TryParse(heightSpecValueField.Text, out changedValue))
                {
                    controlView.HeightSpecification = changedValue;
                    controlView.Layout?.RequestLayout();
                }
            }
        }
    }
}
