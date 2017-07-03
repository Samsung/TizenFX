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
    /// Polygon map object
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public class Polygon : MapObject, IDisposable
    {
        internal Interop.PolygonHandle handle;
        private List<Geocoordinates> _coordinateList;

        /// <summary>
        /// Creates a polygon visual object.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="coordinates">List of geographical coordinates</param>
        /// <param name="color">Background color</param>
        /// <exception cref="ArgumentException">Thrown when input values are invalid.</exception>
        public Polygon(IEnumerable<Geocoordinates> coordinates, Color color) : base()
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || coordinates.Count() < 3)
            {
                err.ThrowIfFailed("given coordinates list should contain at least 3 coordinates");
            }
            _coordinateList = coordinates.ToList();
            var geocoordinateList = new GeocoordinatesList(_coordinateList, false);
            handle = new Interop.PolygonHandle(geocoordinateList.handle, color);
        }

        /// <summary>
        /// Adds or removes clicked event handlers.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public event EventHandler Clicked;

        /// <summary>
        /// Gets or sets visibility for the polygon.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public override bool IsVisible
        {
            get { return handle.IsVisible; }
            set { handle.IsVisible = value; }
        }

        /// <summary>
        /// Gets or sets a list of geographical coordinates of polygon vertices.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public IEnumerable<Geocoordinates> Coordinates
        {
            get
            {
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

                var geocoordinateList = new GeocoordinatesList(coordinates, false);
                if (handle.SetPolygon(geocoordinateList.handle).IsSuccess())
                {
                    _coordinateList = coordinates;
                }
            }
        }

        /// <summary>
        /// Gets or sets background color to fill the polygon.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public Color FillColor
        {
            get
            {
                return handle.FillColor;
            }
            set
            {
                handle.FillColor = value;
            }
        }

        internal override void HandleClickedEvent()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }

        internal override void InvalidateMapObject()
        {
            handle = null;
        }

        internal override Interop.ViewObjectHandle GetHandle()
        {
            return handle;
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _coordinateList.Clear();
                }
                handle.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
