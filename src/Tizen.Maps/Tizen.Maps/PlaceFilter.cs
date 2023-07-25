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

namespace Tizen.Maps
{
    /// <summary>
    /// Place filter information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class PlaceFilter : IDisposable
    {
        internal Interop.PlaceFilterHandle handle;

        /// <summary>
        /// Constructs a new place filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.InvalidOperationException">Thrown when native operation failed to allocate memory.</exception>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceFilter()
        {
            handle = new Interop.PlaceFilterHandle();
        }

        /// <summary>
        /// Destroy the PlaceFilter object.
        /// </summary>
        ~PlaceFilter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets a free-formed address string for this place filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Depending on maps provider which the application has selected,
        /// it may treat <see cref="PlaceFilter.Name"/>, <see cref="PlaceFilter.Keyword"/> and <see cref="PlaceFilter.Address"/>
        /// as the same kind of strings to search places.</remarks>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Address
        {
            get
            {
                return handle.PlaceAddress;
            }
            set
            {
                handle.PlaceAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets an instance of <see cref="PlaceCategory"/> object for this place filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceCategory Category
        {
            get
            {
                return new PlaceCategory(handle.Category);
            }
            set
            {
                handle.Category = value.handle;
            }
        }

        /// <summary>
        /// Gets or sets a keyword for this place filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Depending on maps provider which the application has selected,
        /// it may treat <see cref="PlaceFilter.Name"/>, <see cref="PlaceFilter.Keyword"/> and <see cref="PlaceFilter.Address"/>
        /// as the same kind of strings to search places.</remarks>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Keyword
        {
            get
            {
                return handle.Keyword;
            }
            set
            {
                handle.Keyword = value;
            }
        }

        /// <summary>
        /// Gets or sets a name for this place filter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Depending on maps provider which the application has selected,
        /// it may treat <see cref="PlaceFilter.Name"/>, <see cref="PlaceFilter.Keyword"/> and <see cref="PlaceFilter.Address"/>
        /// as the same kind of strings to search places.</remarks>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Name
        {
            get
            {
                return handle.PlaceName;
            }
            set
            {
                handle.PlaceName = value;
            }
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
}
