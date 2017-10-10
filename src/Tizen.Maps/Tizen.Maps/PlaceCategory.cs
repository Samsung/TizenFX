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
    /// Place category information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlaceCategory : IDisposable
    {
        internal Interop.PlaceCategoryHandle handle;

        /// <summary>
        /// Constructs a search category object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.InvalidOperationException">Thrown when native operation failed to allocate memory.</exception>
        public PlaceCategory()
        {
            handle = new Interop.PlaceCategoryHandle();
        }

        internal PlaceCategory(Interop.PlaceCategoryHandle nativeHandle)
        {
            handle = nativeHandle;
        }


        /// <summary>
        /// Gets or sets an ID for this category.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Id
        {
            get { return handle.Id; }
            set { handle.Id = value; }
        }

        /// <summary>
        /// Gets or sets a name for this category.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get { return handle.Name; }
            set { handle.Name = value; }
        }

        /// <summary>
        /// Gets or sets a URL for this category.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Url
        {
            get { return handle.Url; }
            set { handle.Url = value; }
        }

        /// <summary>
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string which presents this object.</returns>
        public override string ToString()
        {
            return $"{Name}";
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
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
