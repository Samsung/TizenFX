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
    public partial class ObjectView : SelectButton, IObjectView
    {
        private bool selectedAgain = false;

        public new int WidthSpecification
        {
            get
            {
                return base.WidthSpecification;
            }

            set
            {
                if (base.WidthSpecification == value) return;

                base.WidthSpecification = value;
                WidthSpecificationChanged?.Invoke(this, new WidthSpecificationChangedEventArgs(base.WidthSpecification));
            }
        }
        public new int HeightSpecification
        {
            get
            {
                return base.HeightSpecification;
            }

            set
            {
                if (base.HeightSpecification == value) return;

                base.HeightSpecification = value;
                HeightSpecificationChanged?.Invoke(this, new HeightSpecificationChangedEventArgs(base.HeightSpecification));
            }
        }
        
        public new Extents Margin
        {
            get
            {
                return base.Margin;
            }

            set
            {
                if (base.Margin.EqualTo(value)) return;

                base.Margin = new Extents(value);
                MarginChanged?.Invoke(this, new MarginChangedEventArgs(base.Margin));
            }
        }

        public new Extents Padding
        {
            get
            {
                return base.Padding;
            }

            set
            {
                if (base.Padding.EqualTo(value)) return;

                base.Padding = new Extents(value);
                PaddingChanged?.Invoke(this, new PaddingChangedEventArgs(base.Padding));
            }
        }

        public event EventHandler<WidthSpecificationChangedEventArgs> WidthSpecificationChanged;
        public event EventHandler<HeightSpecificationChangedEventArgs> HeightSpecificationChanged;
        public event EventHandler<MarginChangedEventArgs> MarginChanged;
        public event EventHandler<PaddingChangedEventArgs> PaddingChanged;

        public override bool OnKey(Key key)
        {
            if ((IsEnabled == false) || (key == null))
            {
                return false;
            }

            if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    if (IsSelected == true)
                    {
                        selectedAgain = true;
                    }
                }
            }

            bool ret = base.OnKey(key);

            if (selectedAgain == true)
            {
                IsSelected = true;
                selectedAgain = false;
            }

            return ret;
        }

        protected override bool HandleControlStateOnTouch(Touch touch)
        {
            if ((IsEnabled == false) || (touch == null))
            {
                return false;
            }

            PointStateType state = touch.GetState(0);
            switch (state)
            {
                case PointStateType.Up:
                    if (IsSelected == true)
                    {
                        selectedAgain = true;
                    }
                    break;
                default:
                    break;
            }

            bool ret = base.HandleControlStateOnTouch(touch);

            if (selectedAgain == true)
            {
                IsSelected = true;
                selectedAgain = false;
            }

            return ret;
        }

        protected override void OnControlStateChanged(ControlStateChangedEventArgs info)
        {
            if (info.PreviousState.Contains(ControlState.Selected) != info.CurrentState.Contains(ControlState.Selected))
            {
                // RadioButton does not invoke SelectedChanged if button or key
                // is unpressed while its state is selected.
                if (selectedAgain == true)
                {
                    return;
                }

                base.OnControlStateChanged(info);
            }
        }
    }
}
