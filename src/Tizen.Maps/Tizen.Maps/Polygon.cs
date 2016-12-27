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
    public class Polygon : MapObject
    {
        private List<Geocoordinates> _coordinateList;

        public Polygon(IEnumerable<Geocoordinates> coordinates, Color color) : base(CreateNativeHandle(coordinates, color))
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || coordinates.Count() < 3)
            {
                err.ThrowIfFailed("given coordinates list should contain at least 3 coordinates");
            }
            _coordinateList = coordinates.ToList();
        }

        internal Polygon(Interop.ViewObjectHandle nativeHandle) : base(nativeHandle)
        {
        }

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
                    Interop.ViewObject.PolygonForeachPoint(handle, callback, IntPtr.Zero);
                }
                return _coordinateList;
            }
            set
            {
                var coordinates = value.ToList();

                var err = Interop.ErrorCode.InvalidParameter;
                if (coordinates == null || coordinates.Count() < 3)
                {
                    err.ThrowIfFailed("given coordinates list should contain at least 3 coordinates");
                }

                var coordinateList = new GeocoordinatesList(coordinates, false);
                if (Interop.ViewObject.PolygonSetPolygon(handle, coordinateList.handle).IsSuccess())
                {
                    _coordinateList = coordinates;
                }
            }
        }

        public Color FillColor
        {
            get
            {
                byte r, g, b, a;
                Interop.ViewObject.PolygonGetFillColor(handle, out r, out g, out b, out a);
                return new Color(r, g, b, a);
            }
            set
            {
                Interop.ViewObject.PolygonSetFillColor(handle, (byte)value.R, (byte)value.G, (byte)value.B, (byte)value.A);
            }
        }

        private static Interop.ViewObjectHandle CreateNativeHandle(IEnumerable<Geocoordinates> coordinates, Color color)
        {
            if (coordinates == null || coordinates.Count() < 3) return new Interop.ViewObjectHandle(IntPtr.Zero);

            IntPtr nativeHandle;
            var geocoordinateList = new GeocoordinatesList(coordinates.ToList(), false);
            var err = Interop.ViewObject.CreatePolygon(geocoordinateList.handle, (byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A, out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for polygon");
            return new Interop.ViewObjectHandle(nativeHandle);
        }
    }
}
