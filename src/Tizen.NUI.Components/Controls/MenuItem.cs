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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// MenuItem is a class which is used to show a list of items in Menu.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class MenuItem : SelectButton
    {
        private bool selectedAgain = false;

        /// <summary>
        /// Creates a new instance of MenuItem.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public MenuItem()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of MenuItem.
        /// </summary>
        /// <param name="style">Creates MenuItem by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MenuItem(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a MenuItem with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created MenuItem.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MenuItem(ButtonStyle style) : base(style)
        {
            Initialize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
            }

            base.Dispose(type);
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
                // MenuItem does not invoke SelectedChanged if button or key is
                // unpressed while its state is selected.
                if (selectedAgain == true)
                {
                    return;
                }

                base.OnControlStateChanged(controlStateChangedInfo);
            }
        }

        private void Initialize()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.MenuItem;
        }
    }
}
