/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    /// <summary>
    /// It inherits System.EventArgs.
    /// Event ColorChanged of the ColorSelector contains ColorChangedEventArgs as a parameter.
    /// Refer to <see cref="ColorSelector"/>type.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ColorChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets an old color in the color changed event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color OldColor { get; private set; }

        /// <summary>
        /// Gets a new color in the color changed event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color NewColor { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the ColorChangedEventArgs class.
        /// </summary>
        /// <param name="oldColor">Old color.</param>
        /// <param name="newColor">New color.</param>
        /// <since_tizen> preview </since_tizen>
        public ColorChangedEventArgs(Color oldColor, Color newColor)
        {
            this.OldColor = oldColor;
            this.NewColor = newColor;
        }
    }
}
