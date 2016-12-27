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
using System.Collections.Generic;
using System.Linq;

using Color = ElmSharp.Color;

namespace Tizen.Maps
{
    /// <summary>
    /// Polyline map object
    /// </summary>
    public class Polyline : MapObject
    {
        private List<Geocoordinates> _coordinateList;

        /// <summary>
        /// Creates polyline visual object
        /// </summary>
        /// <param name="coordinates">List of geographical coordinates</param>
        /// <param name="color">Line color</param>
        /// <param name="width">The width of line [1 ~ 100] (pixels)</param>
        public Polyline(List<Geocoordinates> coordinates, Color color, int width) : base(CreateNativeHandle(coordinates, color, width))
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || coordinates.Count() < 2)
            {
                err.ThrowIfFailed("given coordinates list should contain at least 2 coordinates");
            }
            _coordinateList = coordinates.ToList();
        }

        internal Polyline(Interop.ViewObjectHandle nativeHandle) : base(nativeHandle)
        {
        }

        /// <summary>
        /// List of geographical coordinates for polyline vertices
        /// </summary>
        public IEnumerable<Geocoordinates> Coordinates
        {
            get
            {
                if (_coordinateList == null)
                {
                    _coordinateList = new List<Geocoordinates>();
                    Interop.ViewObject.CoordinatesCallback callback = (index, nativeHandle, userData) =>
                    {
                        _coordinateList.Add(new Geocoordinates(nativeHandle));
                        return true;
                    };
                    Interop.ViewObject.PolylineForeachPoint(handle, callback, IntPtr.Zero);
                }
                return _coordinateList;
            }
            set
            {
                var coordinates = value.ToList();
                var err = Interop.ErrorCode.InvalidParameter;
                if (coordinates == null || coordinates.Count() < 2)
                {
                    err.ThrowIfFailed("given coordinates list should contain at least 2 coordinates");
                }

                var coordinateList = new GeocoordinatesList(coordinates, false);
                if (Interop.ViewObject.PolylineSetPolyline(handle, coordinateList.handle).IsSuccess())
                {
                    _coordinateList = coordinates;
                }
            }
        }

        /// <summary>
        /// Line color
        /// </summary>
        public Color LineColor
        {
            get
            {
                byte r, g, b, a;
                Interop.ViewObject.PolylineGetColor(handle, out r, out g, out b, out a);
                return new Color(r, g, b, a);
            }
            set
            {
                Interop.ViewObject.PolylineSetColor(handle, (byte)value.R, (byte)value.G, (byte)value.B, (byte)value.A);
            }
        }

        /// <summary>
        /// line width [1 ~ 100 pixels]
        /// </summary>
        public int Width
        {
            get
            {
                int value;
                Interop.ViewObject.PolylineGetWidth(handle, out value);
                return value;
            }
            set
            {
                Interop.ViewObject.PolylineSetWidth(handle, value);
            }
        }

        private static Interop.ViewObjectHandle CreateNativeHandle(IEnumerable<Geocoordinates> coordinates, Color color, int width)
        {
            if (coordinates == null || coordinates.Count() < 2) return new Interop.ViewObjectHandle(IntPtr.Zero);

            IntPtr nativeHandle;
            var coordinateList = new GeocoordinatesList(coordinates.ToList(), false);
            var err = Interop.ViewObject.CreatePolyline(coordinateList.handle, (byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A, width, out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for polyline");
            return new Interop.ViewObjectHandle(nativeHandle);
        }
    }
}
