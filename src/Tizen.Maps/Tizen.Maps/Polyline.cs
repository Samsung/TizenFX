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
    /// The polyline map object.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Polyline : MapObject, IDisposable
    {
        internal Interop.PolylineHandle handle;
        private List<Geocoordinates> _coordinateList;

        /// <summary>
        /// Creates polyline visual object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates">List of geographical coordinates.</param>
        /// <param name="color">Line color.</param>
        /// <param name="width">The width of line [1 ~ 100] (pixels).</param>
        /// <exception cref="ArgumentException">Thrown when input values are invalid.</exception>
        public Polyline(List<Geocoordinates> coordinates, Color color, int width) : base()
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || coordinates.Count() < 2)
            {
                err.ThrowIfFailed("given coordinates list should contain at least 2 coordinates");
            }
            _coordinateList = coordinates.ToList();
            var geocoordinateList = new GeocoordinatesList(_coordinateList);
            handle = new Interop.PolylineHandle(geocoordinateList.handle, color, width);
        }

        /// <summary>
        /// Adds or removes the clicked event handlers.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Clicked;

        /// <summary>
        /// Gets or sets the visibility for polyline.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public override bool IsVisible
        {
            get { return handle.IsVisible; }
            set { handle.IsVisible = value; }
        }

        /// <summary>
        /// Gets or sets a list of geographical coordinates for polyline vertices.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (coordinates == null || coordinates.Count() < 2)
                {
                    err.ThrowIfFailed("given coordinates list should contain at least 2 coordinates");
                }

                var geocoordinateList = new GeocoordinatesList(coordinates, false);
                if (handle.SetPolyline(geocoordinateList.handle).IsSuccess())
                {
                    _coordinateList = coordinates;
                }
            }
        }

        /// <summary>
        /// Gets or sets the line color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color LineColor
        {
            get
            {
                return handle.LineColor;
            }
            set
            {
                handle.LineColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the line width from 1 to 100 pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Width
        {
            get
            {
                return handle.LineWidth;
            }
            set
            {
                handle.LineWidth = value;
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
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
