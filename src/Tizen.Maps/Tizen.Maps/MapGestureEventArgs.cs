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
    /// Event arguments for gesture type map events
    /// </summary>
    public class MapGestureEventArgs : EventArgs
    {
        internal static MapGestureEventArgs Create(IntPtr nativeHandle)
        {
            Interop.ViewGesture type;
            Point screenCoordinate = new Point();
            int touchCount;
            double zoomFactor;
            double rotationAngle;
            Geocoordinates coordinates;

            Interop.ViewEventData.GetGestureType(nativeHandle, out type);
            Interop.ViewEventData.GetPosition(nativeHandle, out screenCoordinate.X, out screenCoordinate.Y);
            Interop.ViewEventData.GetFingers(nativeHandle, out touchCount);
            Interop.ViewEventData.GetZoomFactor(nativeHandle, out zoomFactor);
            Interop.ViewEventData.GetRotationAngle(nativeHandle, out rotationAngle);

            IntPtr coordinate;
            Interop.ViewEventData.GetCoordinates(nativeHandle, out coordinate);
            coordinates = new Geocoordinates(coordinate);
            return new MapGestureEventArgs((GestureType)type, screenCoordinate, coordinates, touchCount, zoomFactor, rotationAngle);
        }

        internal MapGestureEventArgs(GestureType type, Point screenCoordinate, Geocoordinates geocoordinates, int touchCount, double zoomFactor, double rotationAngle)
        {
            GestureType = type;
            Position = screenCoordinate;
            Geocoordinates = geocoordinates;
            TouchCount = touchCount;
            ZoomFactor = zoomFactor;
            RotationAngle = rotationAngle;
        }

        /// <summary>
        /// Type of gesture event
        /// </summary>
        public GestureType GestureType { get; }

        /// <summary>
        /// Screen coordinates for the event
        /// </summary>
        public Point Position { get; }

        /// <summary>
        /// Number of fingers detected in the event
        /// </summary>
        public int TouchCount { get; }

        /// <summary>
        /// Zoom factor for zoom gesture event
        /// </summary>
        public double ZoomFactor { get; }

        /// <summary>
        /// Angle of rotation for rotate gesture event
        /// </summary>
        public double RotationAngle { get; }

        /// <summary>
        /// Geo-coordinates for the event
        /// </summary>
        public Geocoordinates Geocoordinates { get; }
    }
}
