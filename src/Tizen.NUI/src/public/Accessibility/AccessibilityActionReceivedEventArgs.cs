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
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Provides the data for the AccessibilityActionReceived event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AccessibilityActionReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the accessibility action event data.
        /// </summary>
        public AccessibilityAction ActionType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the event has been handled.
        /// </summary>
        public bool Handled { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    struct AccessibilityActionInfo
    {
        public AccessibilityAction ActionType;

        public IntPtr target;
    }
}
