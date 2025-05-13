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
    /// AccessibilityState2 is an enumeration that represents the states of the view to send to accessibility service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityState2
    {
        /// <summary>
        /// Indicates whether the view is enabled or not.
        /// </summary>
        Enabled = 0,
        /// <summary>
        /// Indicates whether a selectable element is currently selected or not.
        /// </summary>
        Selected,
        /// <summary>
        /// Indicates the state of a checkable element.
        /// </summary>
        Checked,
        /// <summary>
        /// Indicates whether an element is currently busy or not.
        /// </summary>
        Busy,
        /// <summary>
        /// Indicates whether an expandable element is currently expanded or collapsed.
        /// </summary>
        Expanded
    }

    /// <summary>
    /// The AccessibilityStates2 structure represents a set of states of the view to communicate to accessibility service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct AccessibilityStates2
    {
        const uint _on = 1;
        uint _bitMask;

        /// <summary>
        /// Gets the state at the specsified name
        /// </summary>
        /// <param name="state">The name of the state</param>
        /// <returns>The state af the specified name</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool this[AccessibilityState2 state]
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

        AccessibilityStates2(int states)
        {
            _bitMask = (uint)states;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static explicit operator int(AccessibilityStates2 state)
        {
            return (int)state._bitMask;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static explicit operator AccessibilityStates2(int states)
        {
            return new AccessibilityStates2(states);
        }
    }

    /// <summary>
    /// Specifies the role of an accessible object.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityRole2
    {
        /// <summary>
        /// A slider
        /// </summary>
        Adjustable = 200,
        /// <summary>
        /// An alert
        /// </summary>
        Alert,
        /// <summary>
        /// A button
        /// </summary>
        Button,
        /// <summary>
        /// A check box
        /// </summary>
        CheckBox,
        /// <summary>
        /// A combo box
        /// </summary>
        ComboBox,
        /// <summary>
        /// A container
        /// </summary>
        Container,
        /// <summary>
        /// A dialog
        /// </summary>
        Dialog,
        /// <summary>
        /// An entry
        /// </summary>
        Entry,
        /// <summary>
        /// A header
        /// </summary>
        Header,
        /// <summary>
        /// An Image
        /// </summary>
        Image,
        /// <summary>
        /// A link
        /// </summary>
        Link,
        /// <summary>
        /// A list
        /// </summary>
        List,
        /// <summary>
        /// An item of the list
        /// </summary>
        ListItem,
        /// <summary>
        /// A menu
        /// </summary>
        Menu,
        /// <summary>
        /// A menu bar
        /// </summary>
        MenuBar,
        /// <summary>
        /// An item of the menu
        /// </summary>
        MenuItem,
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// A password text
        /// </summary>
        PasswordText,
        /// <summary>
        /// A popup menu
        /// </summary>
        PopupMenu,
        /// <summary>
        /// A progress bar
        /// </summary>
        ProgressBar,
        /// <summary>
        /// A radio button
        /// </summary>
        RadioButton,
        /// <summary>
        /// A scroll bar
        /// </summary>
        ScrollBar,
        /// <summary>
        /// A spin button
        /// </summary>
        SpinButton,
        /// <summary>
        /// A tab
        /// </summary>
        Tab,
        /// <summary>
        /// A tab list
        /// </summary>
        TabList,
        /// <summary>
        /// A text
        /// </summary>
        Text,
        /// <summary>
        /// A toggle button
        /// </summary>
        ToggleButton,
        /// <summary>
        /// a tool bar
        /// </summary>
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
        /// Gets the AccessibilityStates property of the view.
        /// </summary>
        /// <returns>The states<see cref="AccessibilityStates2"/> of the view</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates2 GetAccessibilityStates2()
        {

            return (AccessibilityStates2)Object.InternalGetPropertyInt(SwigCPtr, Property.AccessibilityState);
        }

        /// <summary>
        /// Sets the AccessibilityStates property of the view.
        /// </summary>
        /// <param name="states">The states<see cref="AccessibilityStates2"/> value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityStates2(AccessibilityStates2 states)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AccessibilityState, (int)states);
        }

        /// <summary>
        /// Gets the accessibility role of the view.
        /// </summary>
        /// <returns>The role<see cref="AccessibilityRole2"/> of the view</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityRole2 GetAccessibilityRole()
        {
            return (AccessibilityRole2)Object.InternalGetPropertyInt(SwigCPtr, Property.AccessibilityRole);
        }

        /// <summary>
        /// Sets the accessibiltiy role of the view.
        /// </summary>
        /// <param name="role">The role<see cref="AccessibilityRole2"/> value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityRole(AccessibilityRole2 role)
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
