﻿/*
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
    /// Overlay map object.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class Overlay : MapObject, IDisposable
    {
        internal Interop.OverlayHandle handle;

        /// <summary>
        /// Creates a normal overlay map object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates"></param>
        /// <param name="objectToContain"></param>
        /// <exception cref="ArgumentException">Thrown when the input coordinates or objectToContain are invalid.</exception>
	[Obsolete("Deprecated since API10. Might be removed in API12.")]
        public Overlay(Geocoordinates coordinates, EvasObject objectToContain)
            : this(coordinates, objectToContain, Interop.ViewOverlayType.Normal)
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

        /// <summary>
        /// Destroy the Overlay object.
        /// </summary>
        ~Overlay()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets the visibility of an overlay map object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public override bool IsVisible
        {
            get { return handle.IsVisible; }
            set { handle.IsVisible = value; }
        }

        /// <summary>
        /// Gets or sets geographical coordinates for an overlay map object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets or sets minimum zoom level for an overlay map object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API10. Might be removed in API12.")]
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
        /// Gets or sets maximum zoom lever for an overlay map object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API10. Might be removed in API12.")]
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle?.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// The bubble overlay map object.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class BubbleOverlay : Overlay
    {
        /// <summary>
        /// Creates a bubble overlay.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates">The geographical coordinates to be pointed.</param>
        /// <param name="objectToContain">The EvasObject to be shown.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the input coordinates or objectToContain are invalid.</exception>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public BubbleOverlay(Geocoordinates coordinates, EvasObject objectToContain)
            : base(coordinates, objectToContain, Interop.ViewOverlayType.Bubble)
        {
        }
    }

    /// <summary>
    /// The box overlay map object.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class BoxOverlay : Overlay
    {
        /// <summary>
        /// Creates a box overlay.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates">The geographical coordinates to be pointed.</param>
        /// <param name="objectToContain">The EvasObject to be shown.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the input coordinates or objectToContain are invalid</exception>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public BoxOverlay(Geocoordinates coordinates, EvasObject objectToContain)
            : base(coordinates, objectToContain, Interop.ViewOverlayType.Box)
        {
        }
    }
}
