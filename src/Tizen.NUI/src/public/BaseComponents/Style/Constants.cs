/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Enumeration for describing the states of the view.
    /// </summary>
    [FlagsAttribute]
    // Please remove this enum when 'Tizen.NUI.BaseComponents.Button.StateChangedEventArgs' and 'Tizen.NUI.BaseComponents.Slider.StateChangedArgs' are removed.
    [Obsolete("This will be removed in API10. Please use Tizen.NUI.BaseComponents.ControlState instead!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ControlStates
    {
        /// <summary>
        /// The normal state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Normal = 0,
        /// <summary>
        /// The focused state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Focused = 1,
        /// <summary>
        /// The disabled state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Disabled = 2,
        /// <summary>
        /// The Selected state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selected = 4,
        /// <summary>
        /// The Pressed state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Pressed = 8,
        /// <summary>
        /// The DisabledFocused state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DisabledFocused = Disabled | Focused,
        /// <summary>
        /// The SelectedFocused state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SelectedFocused = Focused | Selected,
        /// <summary>
        /// The DisabledSelected state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DisabledSelected = Disabled | Selected,
    }

    //FIXME: Please remove this Extension class when ControlStates is removed.
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class ControlStatesExtension
    {
        public static ControlStates FromControlStateClass(ControlState controlState)
        {
            if (controlState == ControlState.Normal)
                return ControlStates.Normal;
            if (controlState == ControlState.Focused)
                return ControlStates.Focused;
            if (controlState == ControlState.Disabled)
                return ControlStates.Disabled;
            if (controlState == ControlState.Selected)
                return ControlStates.Selected;
            if (controlState == ControlState.Pressed)
                return ControlStates.Pressed;
            if (controlState == ControlState.DisabledFocused)
                return ControlStates.DisabledFocused;
            if (controlState == ControlState.SelectedFocused)
                return ControlStates.SelectedFocused;
            if (controlState == ControlState.DisabledSelected)
                return ControlStates.DisabledSelected;

            return ControlStates.Normal;
        }
    }
}

