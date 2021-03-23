/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabButton is a class which is used for selecting one content in a TabView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabButton : SelectButton
    {
        private bool selectedAgain = false;

        /// <summary>
        /// Creates a new instance of TabButton.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButton()
        {
            GridLayout.SetHorizontalStretch(this, GridLayout.StretchFlags.ExpandAndFill);
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
        [SuppressMessage("Microsoft.Design",
                         "CA1062: Validate arguments of public methods",
                         MessageId = "controlStateChangedInfo",
                         Justification = "OnControlStateChanged is called when controlState is changed so controlStateChangedInfo cannot be null.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
            if (controlStateChangedInfo.PreviousState.Contains(ControlState.Selected) != controlStateChangedInfo.CurrentState.Contains(ControlState.Selected))
            {
                // TabButton does not invoke SelectedChanged if button or key is
                // unpressed while its state is selected.
                if (selectedAgain == true)
                {
                    return;
                }

                base.OnControlStateChanged(controlStateChangedInfo);
            }
        }
    }
}
