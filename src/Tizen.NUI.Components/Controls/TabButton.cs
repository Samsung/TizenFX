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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabButton is a class which is used for selecting one content in a TabView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabButton : SelectButton
    {
        /// <summary>
        /// Creates a new instance of TabButton.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButton()
        {
            GridLayout.SetHorizontalStretch(this, GridLayout.StretchFlags.ExpandAndFill);
        }

        /// <summary>
        /// Sets the control state of a TabButton.
        /// TabButton needs to support this API since 'View.ControlState' is protected
        /// and cannot be reached by TabButtonGroup.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetTabButtonState(ControlState controlState)
        {
            base.ControlState = controlState;
        }

        /// <summary>
        /// Sets Button.IsSelected to true after selecting TabButton since it is
        /// set to false when re-selected according to Button's logic.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnSelectedChanged()
        {
            ControlState = ControlState.Pressed;
            if (!IsSelected)
            {
                IsSelected = true;
            }
        }
    }
}
