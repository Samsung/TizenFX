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

namespace Tizen.Maps
{
    /// <summary>
    /// Place Filter information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceFilter : IDisposable
    {
        internal Interop.PlaceFilterHandle handle;

        /// <summary>
        /// Constructs new place filter
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public PlaceFilter()
        {
            handle = new Interop.PlaceFilterHandle();
        }

        /// <summary>
        /// Filter string for place addresses
        /// </summary>
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
        /// Category filter for places
        /// </summary>
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
        /// Filter keyword for place
        /// </summary>
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
        /// Filter string for place names
        /// </summary>
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
}
