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
using ElmSharp;

namespace Tizen.Maps
{
    /// <summary>
    /// Event arguments for gesture type map events.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MapGestureEventArgs : EventArgs
    {
        internal MapGestureEventArgs(IntPtr nativeHandle)
        {
            using (var handle = new Interop.GestureEventDataHandle(nativeHandle))
            {
                GestureType = (GestureType)handle.GestureType;
                Position = handle.Position;
                TouchCount = handle.FingerCount;
                ZoomFactor = handle.ZoomFactor;
                RotationAngle = handle.RotationAngle;
                Geocoordinates = new Geocoordinates(handle.Coordinates);
            }
        }

        /// <summary>
        /// Gets the type of gesture event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GestureType GestureType { get; }

        /// <summary>
        /// Gets screen coordinates in the event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Point Position { get; }

        /// <summary>
        /// Gets the number of fingers detected in the event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int TouchCount { get; }

        /// <summary>
        /// Gets the zoom factor for zoom gesture event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double ZoomFactor { get; }

        /// <summary>
        /// Gets the angle of rotation for rotate gesture event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double RotationAngle { get; }

        /// <summary>
        /// Gets the geographical coordinates for the event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Geocoordinates Geocoordinates { get; }
    }
}
