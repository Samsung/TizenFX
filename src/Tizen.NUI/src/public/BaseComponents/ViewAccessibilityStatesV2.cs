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
    /// AccessibilityStatesV2 is an enumeration that represents the states of the view to send to accessibility service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Flags]
    public enum AccessibilityStatesV2
    {
        /// <summary>
        /// Indicates whether the view is enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Enabled = 1 << 0,
        /// <summary>
        /// Indicates whether a selectable element is currently selected or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selected = 1 << 1,
        /// <summary>
        /// Indicates the state of a checkable element.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Checked = 1 << 2,
        /// <summary>
        /// Indicates whether an element is currently busy or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Busy = 1 << 3,
        /// <summary>
        /// Indicates whether an expandable element is currently expanded or collapsed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Expanded = 1 << 4
    }

    /// <summary>
    /// Extension methods to help handling <see cref="AccessibilityStatesV2"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class AccessibilityStatesV2Extensions
    {
        /// <summary>
        /// Add or remove a flag.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AccessibilityStatesV2 Set(this AccessibilityStatesV2 self, AccessibilityStatesV2 state, bool value) => value ? Add(self, state) : Remove(self, state);

        /// <summary>
        /// Add a state flag.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AccessibilityStatesV2 Add(this AccessibilityStatesV2 self, AccessibilityStatesV2 state) => self | state;

        /// <summary>
        /// Remove a state flag.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AccessibilityStatesV2 Remove(this AccessibilityStatesV2 self, AccessibilityStatesV2 state) => self & ~state;

        /// <summary>
        /// Query if a state flag included.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool Has(this AccessibilityStatesV2 self, AccessibilityStatesV2 state) => (self & state) != 0;
    }
}
