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
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
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
        /// <param name="states">The states <see cref="AccessibilityStatesV2"/> value to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityStatesV2(AccessibilityStatesV2 states)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.AccessibilityState, (int)states);
        }

        /// <summary>
        /// Adds or removes given state to the current AccessibilityStatesV2 of the view.
        /// </summary>
        /// <param name="states">The states <see cref="AccessibilityStatesV2"/> value to add.</param>
        /// <param name="beAdded">True to add, false to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ChangeAccessibilityStatesV2(AccessibilityStatesV2 states, bool beAdded)
        {
            AccessibilityStatesV2 current = GetAccessibilityStatesV2();

            if (beAdded)
            {
                current = current.Add(states);
            }
            else
            {
                current = current.Remove(states);
            }

            Object.InternalSetPropertyInt(SwigCPtr, Property.AccessibilityState, (int)current);
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

        /// <summary>
        /// Gets or sets the accessibility value of the view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AccessibilityValue
        {
            get => Object.InternalGetPropertyString(SwigCPtr, Property.AccessibilityValue);
            set => Object.InternalSetPropertyString(SwigCPtr, Property.AccessibilityValue, value);
        }

        /// <summary>
        /// Gets or sets whether the view is scrollable or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AccessibilityScrollable
        {
            get => Object.InternalGetPropertyBool(SwigCPtr, Property.AccessibilityScrollable);
            set => Object.InternalSetPropertyBool(SwigCPtr, Property.AccessibilityScrollable, value);
        }
    }
}
