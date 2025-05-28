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
        const uint c_on = 1;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool this[AccessibilityStateV2 state]
        {
            get
            {
                return Convert.ToBoolean(_bitMask & (c_on << (int)state));
            }
            set
            {
                if (value)
                {
                    _bitMask |= (c_on << (int)state);
                }
                else
                {
                    _bitMask &= ~(c_on << (int)state);
                }
            }
        }

        AccessibilityStatesV2(int states)
        {
            _bitMask = (uint)states;
        }

        /// <summary>
        /// Converts an <see cref="AccessibilityStatesV2"/> enumeration value to an integer.
        /// </summary>
        /// <param name="state">The <see cref="AccessibilityStatesV2"/> value to convert.</param>
        /// <returns>The integer representation of the specified <see cref="AccessibilityStatesV2"/> value.</returns>
        /// <remarks>
        /// This explicit operator retrieves the internal bitmask value of the <see cref="AccessibilityStatesV2"/> enumeration,
        /// which represents the combined state flags in a single integer.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static explicit operator int(AccessibilityStatesV2 state)
        {
            return (int)state._bitMask;
        }

        /// <summary>
        /// Converts an integer to an <see cref="AccessibilityStatesV2"/> enumeration value.
        /// </summary>
        /// <param name="states">The integer value to convert.</param>
        /// <returns>A new instance of <see cref="AccessibilityStatesV2"/> initialized with the specified integer value.</returns>
        /// <remarks>
        /// This explicit operator creates a new <see cref="AccessibilityStatesV2"/> object using the provided integer value,
        /// which is interpreted as a bitmask representing multiple state flags.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static explicit operator AccessibilityStatesV2(int states)
        {
            return new AccessibilityStatesV2(states);
        }
    }
}
