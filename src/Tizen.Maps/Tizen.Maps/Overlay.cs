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
    public class Overlay : MapObject, IDisposable
    {
        internal Interop.OverlayHandle handle;

        /// <summary>
        /// Creates normal overlay map object
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="objectToContain"></param>
        /// <exception cref="ArgumentException">Throws if input coordinates or objectToContain are invalid</exception>
        public Overlay(Geocoordinates coordinates, EvasObject objectToContain) : this(coordinates, objectToContain, Interop.ViewOverlayType.Normal)
        {
        }

        internal Overlay(Geocoordinates coordinates, EvasObject objectToContain, Interop.ViewOverlayType type)
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || objectToContain == null)
            {
                err.ThrowIfFailed("given coordinates or parent evas object is null");
            }
            handle = new Interop.OverlayHandle(coordinates.handle, objectToContain, type);
        }

        public override bool IsVisible
        {
            get { return handle.IsVisible; }
            set { handle.IsVisible = value; }
        }

        /// <summary>
        /// Geographical coordinates for overlay
        /// </summary>
        public Geocoordinates Coordinates
        {
            get
            {
                return new Geocoordinates(handle.Coordinates);
            }
            set
            {
                // Overlay takes ownership of the native handle.
                handle.Coordinates = value.handle;
                value.handle.HasOwnership = false;
            }
        }

        /// <summary>
        /// Minimum zoom level for overlay
        /// </summary>
        public int MinimumZoomLevel
        {
            get
            {
                return handle.MinZoomLevel;
            }
            set
            {
                handle.MinZoomLevel = value;
            }
        }

        /// <summary>
        /// Maximum zoom lever for overlay
        /// </summary>
        public int MaximumZoomLevel
        {
            get
            {
                return handle.MaxZoomLevel;
            }
            set
            {
                handle.MaxZoomLevel = value;
            }
        }

        // Overlay object does not support click events
        internal override void HandleClickedEvent()
        {
            throw new NotSupportedException("Overlay object does not support click events");
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
                handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// Bubble overlay map object
    /// </summary>
    public class BubbleOverlay : Overlay
    {
        /// <summary>
        /// Creates Box overlay
        /// </summary>
        /// <exception cref="ArgumentException">Throws if input coordinates or objectToContain are invalid</exception>
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
        /// <exception cref="ArgumentException">Throws if input coordinates or objectToContain are invalid</exception>
        public BoxOverlay(Geocoordinates coordinates, EvasObject objectToContain) : base(coordinates, objectToContain, Interop.ViewOverlayType.Box)
        {
        }
    }
}
