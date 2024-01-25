/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// ICustomAwareDeviceFocusAlgorithm inherits from <see cref="Tizen.NUI.FocusManager.ICustomFocusAlgorithm"/>
    /// ICustomAwareDeviceFocusAlgorithm is used to provide the custom keyboard focus algorithm for retrieving the next focusable view.<br />
    /// The application can implement the interface and override the keyboard focus behavior.<br />
    /// If the focus is changing within a layout container, then the layout container is queried first to provide the next focusable view.<br />
    /// If this does not provide a valid view, then the Keyboard FocusManager will check focusable properties to determine the next focusable actor.<br />
    /// If focusable properties are not set, then the keyboard FocusManager calls the GetNextFocusableView() method of this interface.<br />
    /// This interface calls GetNextFocusableView() with deviceName. <br />
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICustomAwareDeviceFocusAlgorithm : FocusManager.ICustomFocusAlgorithm
    {
        /// <summary>
        /// Get the next focus actor.
        /// </summary>
        /// <param name="current">The current focus view.</param>
        /// <param name="proposed">The proposed focus view</param>
        /// <param name="direction">The focus move direction</param>
        /// <param name="deviceName">The name of device the key event originated from</param>
        /// <returns>The next focus actor.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View GetNextFocusableView(View current, View proposed, View.FocusDirection direction, string deviceName);
    }
}
