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
using EvasObject = ElmSharp.EvasObject;

namespace Tizen.Maps
{
    /// <summary>
    /// Overlay map object
    /// </summary>
    public class Overlay : MapObject
    {
        private EvasObject _containedObject;

        /// <summary>
        /// Creates normal overlay map object
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="objectToContain"></param>
        public Overlay(Geocoordinates coordinates, EvasObject objectToContain) : this(coordinates, objectToContain, Interop.ViewOverlayType.Normal)
        {
        }

        internal Overlay(Interop.ViewObjectHandle nativeHandle) : base(nativeHandle)
        {
        }

        internal Overlay(Geocoordinates coordinates, EvasObject objectToContain, Interop.ViewOverlayType type) : base(CreateNativeHandle(coordinates, objectToContain, type))
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || objectToContain == null)
            {
                err.ThrowIfFailed("given coordinates or parent evas object is null");
            }
            _containedObject = objectToContain;
        }

        /// <summary>
        /// Geographical coordinates for overlay
        /// </summary>
        public Geocoordinates Coordinates
        {
            get
            {
                IntPtr nativeHandle;
                Interop.ViewObject.OverlayGetCoordinates(handle, out nativeHandle);
                return new Geocoordinates(nativeHandle);
            }
            set
            {
                // Overlay takes ownership of the native handle.
                IntPtr nativeHandle;
                var err = Interop.Coordinates.Clone(value.handle, out nativeHandle);
                err.WarnIfFailed("Failed to clone native handle for coordinates");

                Interop.CoordinatesHandle clonedHandle = new Interop.CoordinatesHandle(nativeHandle);
                err = Interop.ViewObject.OverlaySetCoordinates(handle, clonedHandle);
                if (err.WarnIfFailed("Failed to set coordinates to overlay"))
                {
                    clonedHandle.ReleaseOwnership();
                }
            }
        }

        /// <summary>
        /// Minimum zoom level for overlay
        /// </summary>
        public int MinimumZoomLevel
        {
            get
            {
                int value;
                Interop.ViewObject.OverlayGetMinZoomLevel(handle, out value);
                return value;
            }
            set
            {
                Interop.ViewObject.OverlaySetMinZoomLevel(handle, value);
            }
        }

        /// <summary>
        /// Maximum zoom lever for overlay
        /// </summary>
        public int MaximumZoomLevel
        {
            get
            {
                int value;
                Interop.ViewObject.OverlayGetMaxZoomLevel(handle, out value);
                return value;
            }
            set
            {
                Interop.ViewObject.OverlaySetMaxZoomLevel(handle, value);
            }
        }

        private static Interop.ViewObjectHandle CreateNativeHandle(Geocoordinates coordinates, EvasObject objectToContain, Interop.ViewOverlayType type)
        {
            if (coordinates == null || objectToContain == null) return new Interop.ViewObjectHandle(IntPtr.Zero);

            IntPtr nativeHandle;
            var err = Interop.Coordinates.Clone(coordinates.handle, out nativeHandle);
            err.ThrowIfFailed("Failed to clone native handle for coordinates");

            Interop.CoordinatesHandle clonedHandle = new Interop.CoordinatesHandle(nativeHandle);
            err = Interop.ViewObject.CreateOverlay(clonedHandle, objectToContain, type, out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for Overlay");

            clonedHandle.ReleaseOwnership();
            return new Interop.ViewObjectHandle(nativeHandle);
        }
    }

    /// <summary>
    /// Bubble overlay map object
    /// </summary>
    public class BubbleOverlay : Overlay
    {
        public BubbleOverlay(Geocoordinates coordinates, EvasObject objectToContain) : base(coordinates, objectToContain, Interop.ViewOverlayType.Bubble)
        {
        }
    }

    /// <summary>
    /// Box Overlay map object
    /// </summary>
    public class BoxOverlay : Overlay
    {
        /// <summary>
        /// Creates Box overlay
        /// </summary>
        public BoxOverlay(Geocoordinates coordinates, EvasObject objectToContain) : base(coordinates, objectToContain, Interop.ViewOverlayType.Box)
        {
        }
    }
}
