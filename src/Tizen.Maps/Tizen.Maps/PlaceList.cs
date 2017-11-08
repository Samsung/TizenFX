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

namespace Tizen.Maps
{
    /// <summary>
    /// List of <see cref="Place"/> objects to be used in <see cref="MapService"/> APIs.
    /// </summary>
    internal class PlaceList : IDisposable
    {
        internal Interop.PlaceListHandle handle;
        private List<Place> _list;

        internal PlaceList(Interop.PlaceListHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Destroy the PlaceList object.
        /// </summary>
        ~PlaceList()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets an iterator for the addresses in this list.
        /// </summary>
        public IEnumerable<Place> Places
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<Place>();
                    handle.Foreach(placeHandle => _list.Add(new Place(placeHandle)));
                }
                return _list;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
