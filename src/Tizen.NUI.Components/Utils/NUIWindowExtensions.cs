/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Extension class which provides extension methods of Tizen.NUI.Window to
    /// use Tizen.NUI.Components classes in Tizen.NUI.Window class' methods.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class NUIWindowExtentions
    {
        /// <summary>
        /// Returns the default navigator of the given window.
        /// </summary>
        /// <returns>The default navigator of the given window.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument window is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Navigator GetDefaultNavigator(this Window window)
        {
            return Navigator.GetDefaultNavigator(window);
        }
    }
}
