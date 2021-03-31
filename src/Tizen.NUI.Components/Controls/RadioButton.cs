/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// RadioButton is the Class that describe the control which can be checked, but not cleared by a user.
    /// </summary>
    /// <code>
    /// RadioButton radio = new RadioButton("C_RadioButton_WhiteText");
    /// radio.Size = new Size(200, 64, 0);
    /// radio.Position = new Position(500, posY, 0);
    /// radio.Text = "RadioButton";
    /// radio.Focusable = true;
    /// </code>
    /// <since_tizen> 8 </since_tizen>
    public class RadioButton : SelectButton
    {
        private bool selectedAgain = false;

        static RadioButton() { }

        /// <summary>
        /// Creates a new instance of a RadioButton.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public RadioButton() : base() { }
        /// <summary>
        /// Creates a new instance of a RadioButton with style.
        /// </summary>
        /// <param name="style"></param>
        /// <since_tizen> 8 </since_tizen>
        public RadioButton(string style) : base(style) { }
        /// <summary>
        /// Creates a new instance of a RadioButton with style.
        /// </summary>
        /// <param name="buttonStyle"></param>
        /// <since_tizen> 8 </since_tizen>
        public RadioButton(ButtonStyle buttonStyle) : base(buttonStyle) { }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            SetAccessibilityConstructor(Role.RadioButton);
        }

        /// <summary>
        /// Get RadioButtonGroup to which this selections belong.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new RadioButtonGroup ItemGroup
        {
            get
            {
                return base.ItemGroup as RadioButtonGroup;
            }
            internal set
            {
                base.ItemGroup = value;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
