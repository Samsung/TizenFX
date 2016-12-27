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

namespace Tizen.Maps
{
    /// <summary>
    /// Class representing geographical area
    /// </summary>
    public class Area
    {
        internal Interop.AreaHandle handle;

        /// <summary>
        /// Constructs rectangular area
        /// </summary>
        /// <param name="topLeft">Top left coordinate of the area</param>
        /// <param name="bottomRight">Bottom left coordinate of the area</param>
        /// <exception cref="ArgumentException">Throws if input coordinates are invalid</exception>
        /// <exception cref="InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public Area(Geocoordinates topLeft, Geocoordinates bottomRight)
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (topLeft == null || bottomRight == null)
            {
                err.ThrowIfFailed("Need valid coordinates, given null");
            }

            IntPtr nativeHandle;
            err = Interop.Area.CreateRectangle(topLeft.handle, bottomRight.handle, out nativeHandle);
            err.ThrowIfFailed("Failed to create native rectangular area handle");

            handle = new Interop.AreaHandle(nativeHandle);
        }

        /// <summary>
        /// Constructs circular area
        /// </summary>
        /// <param name="center">Coordinate for center of the area</param>
        /// <param name="radius">Radius of the area</param>
        /// <exception cref="ArgumentException">Throws if input coordinates are invalid</exception>
        /// <exception cref="InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public Area(Geocoordinates center, double radius)
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (center == null)
            {
                err.ThrowIfFailed("Need valid center coordinates, given null");
            }

            IntPtr nativeHandle;
            err = Interop.Area.CreateCircle(center.handle, radius, out nativeHandle);
            err.ThrowIfFailed("Failed to create native circular area handle");

            handle = new Interop.AreaHandle(nativeHandle);
        }

        internal Area(IntPtr nativeHandle)
        {
            handle = new Interop.AreaHandle(nativeHandle);
        }
    }
}
