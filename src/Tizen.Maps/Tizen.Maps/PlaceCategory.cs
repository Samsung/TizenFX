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
    /// Place Category information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceCategory
    {
        internal Interop.PlaceCategoryHandle handle;
        protected string _id;
        protected string _name;
        protected string _url;

        /// <summary>
        /// Constructs search category object
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public PlaceCategory()
        {
            IntPtr nativeHandle;
            var err = Interop.PlaceCategory.Create(out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for Place Category");

            handle = new Interop.PlaceCategoryHandle(nativeHandle);
        }

        internal PlaceCategory(IntPtr nativeHandle)
        {
            handle = new Interop.PlaceCategoryHandle(nativeHandle);
            Initialize();
        }

        /// <summary>
        /// ID for this category
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                var err = Interop.PlaceCategory.SetId(handle, value);
                if (err.WarnIfFailed("Failed to set id for place category"))
                {
                    _id = value;
                }
            }
        }

        /// <summary>
        /// Name for this category
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                var err = Interop.PlaceCategory.SetName(handle, value);
                if (err.WarnIfFailed("Failed to set name for place category"))
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// URL for this category
        /// </summary>
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                var err = Interop.PlaceCategory.SetUrl(handle, value);
                if (err.WarnIfFailed("Failed to set URL for place category"))
                {
                    _url = value;
                }
            }
        }

        internal void Initialize()
        {
            Interop.PlaceCategory.GetId(handle, out _id);
            Interop.PlaceCategory.GetName(handle, out _name);
            Interop.PlaceCategory.GetUrl(handle, out _url);
        }
    }
}
