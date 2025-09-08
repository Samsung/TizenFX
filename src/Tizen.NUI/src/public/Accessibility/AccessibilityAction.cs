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

using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Specifies the accessibility action sent from the accessibility service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AccessibilityAction
    {
        /// <summary>
        /// The action indicates that the view is activated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Activated,

        /// <summary>
        /// The action indicates that the highlight goes out of the view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Escape,

        /// <summary>
        /// The action indicates that the value of the view indreases.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Increment,

        /// <summary>
        /// The action indicates that the value of the view decreases.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Decrement,

        /// <summary>
        /// The action indicates that scrolling occurs in the child of the view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ScrollToChild
    }
}
