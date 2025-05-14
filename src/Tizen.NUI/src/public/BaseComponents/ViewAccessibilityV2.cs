/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AccessibilityStateV2 is an enumeration that represents the states of the view to send to accessibility service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityStateV2
    {
        /// <summary>
        /// Indicates whether the view is enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Enabled = 0,
        /// <summary>
        /// Indicates whether a selectable element is currently selected or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selected,
        /// <summary>
        /// Indicates the state of a checkable element.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Checked,
        /// <summary>
        /// Indicates whether an element is currently busy or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Busy,
        /// <summary>
        /// Indicates whether an expandable element is currently expanded or collapsed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Expanded
    }

    /// <summary>
    /// The AccessibilityStatesV2 structure represents a set of states of the view to communicate to accessibility service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct AccessibilityStatesV2
    {
        const uint _on = 1;
        private uint _bitMask;

        /// <summary>
        /// Gets or sets the value of the specified accessibility state flag using bitmask operations.
        /// </summary>
        /// <param name="state">The <see cref="AccessibilityStateV2"/> enum value representing the accessibility state to check or modify.</param>
        /// <returns>
        /// <c>true</c> if the specified state flag is set in the bitmask; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This indexer uses bitwise operations to efficiently store and retrieve multiple boolean state flags
        /// in a single integer field (_bitMask). Each state corresponds to a specific bit position determined
        /// by its enum value.
        /// </remarks>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool this[AccessibilityStateV2 state]
        {
            get
            {
                return Convert.ToBoolean(_bitMask & (_on << (int)state));
            }
            set
            {
                if (value)
                {
                    _bitMask |= (_on << (int)state);
                }
                else
                {
                    _bitMask &= ~(_on << (int)state);
                }
            }
        }

        AccessibilityStatesV2(int states)
        {
            _bitMask = (uint)states;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static explicit operator int(AccessibilityStatesV2 state)
        {
            return (int)state._bitMask;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static explicit operator AccessibilityStatesV2(int states)
        {
            return new AccessibilityStatesV2(states);
        }
    }

    /// <summary>
    /// Specifies the role of an accessible object.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityRoleV2
    {
        /// <summary>
        /// A slider
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Adjustable = 200,
        /// <summary>
        /// An alert
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Alert,
        /// <summary>
        /// A button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Button,
        /// <summary>
        /// A check box
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        CheckBox,
        /// <summary>
        /// A combo box
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ComboBox,
        /// <summary>
        /// A container
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Container,
        /// <summary>
        /// A dialog
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Dialog,
        /// <summary>
        /// An entry
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Entry,
        /// <summary>
        /// A header
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Header,
        /// <summary>
        /// An Image
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Image,
        /// <summary>
        /// A link
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Link,
        /// <summary>
        /// A list
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        List,
        /// <summary>
        /// An item of the list
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ListItem,
        /// <summary>
        /// A menu
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Menu,
        /// <summary>
        /// A menu bar
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MenuBar,
        /// <summary>
        /// An item of the menu
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MenuItem,
        /// <summary>
        /// None
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        None,
        /// <summary>
        /// A password text
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PasswordText,
        /// <summary>
        /// A popup menu
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PopupMenu,
        /// <summary>
        /// A progress bar
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ProgressBar,
        /// <summary>
        /// A radio button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        RadioButton,
        /// <summary>
        /// A scroll bar
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ScrollBar,
        /// <summary>
        /// A spin button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SpinButton,
        /// <summary>
        /// A tab
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Tab,
        /// <summary>
        /// A tab list
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TabList,
        /// <summary>
        /// A text
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Text,
        /// <summary>
        /// A toggle button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ToggleButton,
        /// <summary>
        /// a tool bar
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Toolbar,
    }

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        ///////////////////////////////////////////////////////////////////
        // ************ Accessibility Methods for Version 2 ************ //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the AccessibilityStatesV2 property of the view.
        /// </summary>
        /// <returns>The states<see cref="AccessibilityStatesV2"/> of the view</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStatesV2 GetAccessibilityStatesV2()
        {
            return (AccessibilityStatesV2)Object.InternalGetPropertyInt(SwigCPtr, Property.AccessibilityState);
        }

        /// <summary>
        /// Sets the AccessibilityStatesV2 property of the view.
        /// </summary>
        /// <param name="states">The states<see cref="AccessibilityStatesV2"/> value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityStatesV2(AccessibilityStatesV2 states)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AccessibilityState, (int)states);
        }

        /// <summary>
        /// Gets the accessibility role of the view.
        /// </summary>
        /// <returns>The role<see cref="AccessibilityRoleV2"/> of the view</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityRoleV2 GetAccessibilityRoleV2()
        {
            return (AccessibilityRoleV2)Object.InternalGetPropertyInt(SwigCPtr, Property.AccessibilityRole);
        }

        /// <summary>
        /// Sets the accessibiltiy role of the view.
        /// </summary>
        /// <param name="role">The role<see cref="AccessibilityRoleV2"/> value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityRoleV2(AccessibilityRoleV2 role)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AccessibilityRole, (int)role);
        }

        /// <summary>
        /// Controls whether the view is modal or not.
        /// </summary>
        /// <remarks>
        /// False by default.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AccessibilityIsModal
        {
            get
            {
                return Object.InternalGetPropertyBool(SwigCPtr, Property.AccessibilityIsModal);
            }
            set
            {
                Object.InternalSetPropertyBool(SwigCPtr, Property.AccessibilityIsModal, value);
            }
        }

    }
}
