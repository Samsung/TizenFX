/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Interface representing objects which can store numeric value.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiValue
    {
        /// <summary>
        /// Gets the lowest possible value.
        /// </summary>
        /// <returns> The minimum value </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double AccessibilityGetMinimum();

        /// <summary>
        /// Gets the current numeric value.
        /// </summary>
        /// <remarks>
        /// The application may set the "value_format" attribute to one of the
        /// following values in order to customize what is read by the Screen Reader:
        /// 1. "percent" (the default) - AccessibilityGetCurrent() normalized as
        ///    a percentage of the range [AccessibilityGetMinimum(), AccessibilityGetMaximum()],
        /// 2. "number" - AccessibilityGetCurrent() verbatim,
        /// 3. "text" - AccessibilityGetValueText() is used instead of AccessibilityGetCurrent()
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double AccessibilityGetCurrent();

        /// <summary>
        /// Gets the formatted current value.
        /// </summary>
        /// <remarks>
        /// This does not have to be AccessibilityGetCurrent() formatted in any
        /// particular way, i.e. it may be an arbitrary string, e.g. "small font size"
        /// for the numeric value 10.0. The return value of this method is only
        /// used if the "value_format" attribute is "text".
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetValueText();

        /// <summary>
        /// Gets the highest possible value.
        /// </summary>
        /// <returns> The highest value </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double AccessibilityGetMaximum();

        /// <summary>
        /// Sets the current value.
        /// </summary>
        /// <param name="value"> The current value to set </param>
        /// <returns> True if value could have been assigned, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySetCurrent(double value);

        /// <summary>
        /// Gets the lowest increment that can be distinguished.
        /// </summary>
        /// <returns> The lowest increment </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double AccessibilityGetMinimumIncrement();
    }
}
