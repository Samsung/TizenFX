/*
* Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Common
{
    /// <summary>
    /// The IWindowProvider interface provides the window handle and information about the window's position, size, etc.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public interface IWindowProvider
    {
        /// <summary>
        /// Gets the window handle
        /// </summary>
        /// <remarks>
        /// This handle represents Ecore_Wl2_Window on native.
        /// </remarks>
        IntPtr WindowHandle { get; }

        /// <summary>
        /// Gets the x-coordinate of the window's position.
        /// </summary>
        float X { get; }
        /// <summary>
        /// Gets the y-coordinate of the window's position.
        /// </summary>
        float Y { get; }

        /// <summary>
        /// Gets the width of the window.
        /// </summary>
        float Width { get; }

        /// <summary>
        /// Gets the height of the window.
        /// </summary>
        float Height { get; }

        /// <summary>
        /// Gets the rotation of the window in degrees. The value can only be 0, 90, 180, or 270.
        /// </summary>
        int Rotation { get; }
    }
}
