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
    public class Marker : MapObject
    {
        internal Marker(Interop.ViewObjectHandle nativeHandle) : base(nativeHandle)
        {
        }

        internal Marker(Geocoordinates coordinates, string imagePath, Interop.ViewMarkerType type) : this(CreateNativeHandle(coordinates, imagePath, type))
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || imagePath == null)
            {
                err.ThrowIfFailed("given coordinates or imagePath is null");
            }
        }

        public Geocoordinates Position
        {
            get
            {
                IntPtr nativeHandle;
                Interop.ViewObject.MarkerGetCoordinates(handle, out nativeHandle);
                return new Geocoordinates(nativeHandle);
            }
            set
            {
                // Marker takes ownership of the native handle.
                IntPtr nativeHandle;
                var err = Interop.Coordinates.Clone(value.handle, out nativeHandle);
                err.WarnIfFailed("Failed to clone native handle for coordinates");

                Interop.CoordinatesHandle clonedHandle = new Interop.CoordinatesHandle(nativeHandle);
                err = Interop.ViewObject.MarkerSetCoordinates(handle, clonedHandle);
                if (err.WarnIfFailed("Failed to set coordinates to marker"))
                {
                    clonedHandle.ReleaseOwnership();
                }
            }
        }

        public string ImagePath
        {
            get
            {
                string value;
                Interop.ViewObject.MarkerGetImageFile(handle, out value);
                return value;
            }
            set
            {
                Interop.ViewObject.MarkerSetImageFile(handle, value);
            }
        }

        public Size MarkerSize
        {
            get
            {
                int w, h;
                Interop.ViewObject.MarkerGetSize(handle, out w, out h);
                return new Size(w, h);
            }
            set
            {
                Interop.ViewObject.MarkerResize(handle, value.Width, value.Height);
            }
        }

        public int ZOrder
        {
            get
            {
                int value;
                Interop.ViewObject.MarkerGetZOrder(handle, out value);
                return value;
            }
            set
            {
                Interop.ViewObject.MarkerSetZOrder(handle, value);
            }
        }

        public void Resize(Size newSize)
        {
            MarkerSize = newSize;
        }

        public void Move(Geocoordinates newPosition)
        {
            Position = newPosition;
        }

        private static Interop.ViewObjectHandle CreateNativeHandle(Geocoordinates coordinates, string imagePath, Interop.ViewMarkerType type)
        {
            if (coordinates == null || imagePath == null) return new Interop.ViewObjectHandle(IntPtr.Zero);

            IntPtr nativeHandle;
            var err = Interop.Coordinates.Clone(coordinates.handle, out nativeHandle);
            err.WarnIfFailed("Failed to clone native handle for coordinates");

            Interop.CoordinatesHandle clonedHandle = new Interop.CoordinatesHandle(nativeHandle);
            err = Interop.ViewObject.CreateMarker(clonedHandle, imagePath, type, out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for marker");

            clonedHandle.ReleaseOwnership();
            return new Interop.ViewObjectHandle(nativeHandle);
        }
    }

    public class Pin : Marker
    {
        public Pin(Geocoordinates coordinates, string imagePath) : base(coordinates, imagePath, Interop.ViewMarkerType.Pin)
        {
        }
    }

    public class Sticker : Marker
    {
        public Sticker(Geocoordinates coordinates, string imagePath) : base(coordinates, imagePath, Interop.ViewMarkerType.Sticker)
        {
        }
    }
}
