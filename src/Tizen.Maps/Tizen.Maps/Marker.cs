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
    /// Marker map object
    /// </summary>
    public class Marker : MapObject, IDisposable
    {
        internal Interop.MarkerHandle handle;

        internal Marker(Geocoordinates coordinates, string imagePath, Interop.ViewMarkerType type)
        {
            var err = Interop.ErrorCode.InvalidParameter;
            if (coordinates == null || imagePath == null)
            {
                err.ThrowIfFailed("given coordinates or imagePath is null");
            }
            handle = new Interop.MarkerHandle(coordinates.handle, imagePath, type);
        }

        /// <summary>
        /// Clicked event
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// Marker's visibility
        /// </summary>
        public override bool IsVisible
        {
            get
            {
                return handle.IsVisible;
            }
            set
            {
                handle.IsVisible = value;
            }
        }

        /// <summary>
        /// Geographical coordinates for marker
        /// </summary>
        public Geocoordinates Coordinates
        {
            get
            {
                return new Geocoordinates(handle.Coordinates);
            }
            set
            {
                handle.Coordinates = value.handle;

                // Marker takes ownership of the native handle.
                value.handle.HasOwnership = false;
            }
        }

        /// <summary>
        /// Image file path for marker
        /// </summary>
        public string ImagePath
        {
            get
            {
                return handle.ImageFile;
            }
            set
            {
                handle.ImageFile = value;
            }
        }

        /// <summary>
        /// Screen size for marker
        /// </summary>
        public Size MarkerSize
        {
            get
            {
                return handle.MarkerSize;
            }
            set
            {
                handle.MarkerSize = value;
            }
        }

        /// <summary>
        /// Z-order for marker
        /// </summary>
        public int ZOrder
        {
            get
            {
                return handle.ZOrder;
            }
            set
            {
                handle.ZOrder = value;
            }
        }

        /// <summary>
        /// Changes marker size
        /// </summary>
        /// <param name="newSize">New size</param>
        public void Resize(Size newSize)
        {
            MarkerSize = newSize;
        }

        /// <summary>
        /// Changes marker coordinates
        /// </summary>
        /// <param name="newPosition">New position for marker</param>
        public void Move(Geocoordinates newPosition)
        {
            Coordinates = newPosition;
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
                handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }


        #endregion
    }

    /// <summary>
    /// Pin type marker map object
    /// </summary>
    public class Pin : Marker
    {
        /// <summary>
        /// Creates Pin type parker
        /// </summary>
        /// <param name="coordinates">Marker coordinates</param>
        /// <param name="imagePath">Image path</param>
        public Pin(Geocoordinates coordinates, string imagePath) : base(coordinates, imagePath, Interop.ViewMarkerType.Pin)
        {
        }
    }

    /// <summary>
    /// Sticker type marker map object
    /// </summary>
    public class Sticker : Marker
    {
        /// <summary>
        /// Creates Sticker type parker
        /// </summary>
        /// <param name="coordinates">Marker coordinates</param>
        /// <param name="imagePath">Image path</param>
        public Sticker(Geocoordinates coordinates, string imagePath) : base(coordinates, imagePath, Interop.ViewMarkerType.Sticker)
        {
        }
    }
}
