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
    /// Place information, used in Place Discovery and Search
    /// </summary>
    public class Place : IDisposable
    {
        internal Interop.PlaceHandle handle;

        internal Place(Interop.PlaceHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Place ID
        /// </summary>
        public string Id
        {
            get
            {
                return handle.Id;
            }
        }

        /// <summary>
        /// Place Name
        /// </summary>
        public string Name
        {
            get
            {
                return handle.Name;
            }
        }

        /// <summary>
        /// Place URI
        /// </summary>
        public string Uri
        {
            get
            {
                return handle.Uri;
            }
        }

        /// <summary>
        /// Distance from the center of the search area
        /// </summary>
        public int Distance
        {
            get
            {
                return handle.Distance;
            }
        }

        /// <summary>
        /// Place location
        /// </summary>
        public Geocoordinates Coordinates
        {
            get
            {
                return new Geocoordinates(handle.Coordinates);
            }
        }

        /// <summary>
        /// Place address
        /// </summary>
        public PlaceAddress Address
        {
            get
            {
                return new PlaceAddress(handle.Address);
            }
        }

        /// <summary>
        /// Rating for the place
        /// </summary>
        public PlaceRating Rating
        {
            get
            {
                return new PlaceRating(handle.Rating);
            }
        }

        /// <summary>
        /// Place image supplier link
        /// </summary>
        public PlaceLink Supplier
        {
            get
            {
                return new PlaceLink(handle.Supplier);
            }
        }

        /// <summary>
        /// Place image related link
        /// </summary>
        public PlaceLink Related
        {
            get
            {
                return new PlaceLink(handle.Related);
            }
        }

        /// <summary>
        /// All properties attached with this place
        /// </summary>
        public IDictionary<string, string> Properties
        {
            get
            {
                var properties = new Dictionary<string, string>();
                handle.ForeachProperty((key, value) => properties[key] = value);
                return properties;
            }
        }

        /// <summary>
        /// All categories attached with this place
        /// </summary>
        public IEnumerable<PlaceCategory> Categories
        {
            get
            {
                var categories = new List<PlaceCategory>();
                handle.ForeachCategory((categoryHandle) => categories.Add(new PlaceCategory(categoryHandle)));
                return categories;
            }
        }

        /// <summary>
        /// All attributes attached with this place
        /// </summary>
        public IEnumerable<PlaceAttribute> Attributes
        {
            get
            {
                var attributes = new List<PlaceAttribute>();
                handle.ForeachAttribute((attributeHandle) => attributes.Add(new PlaceAttribute(attributeHandle)));
                return attributes;
            }
        }

        /// <summary>
        /// All contacts attached with this place
        /// </summary>
        public IEnumerable<PlaceContact> Contacts
        {
            get
            {
                var contacts = new List<PlaceContact>();
                handle.ForeachContact((contactHandle) => contacts.Add(new PlaceContact(contactHandle)));
                return contacts;
            }
        }

        /// <summary>
        /// All editorials attached with this place
        /// </summary>
        public IEnumerable<PlaceEditorial> Editorials
        {
            get
            {
                var editorials = new List<PlaceEditorial>();
                handle.ForeachEditorial((editorialHandle) => editorials.Add(new PlaceEditorial(editorialHandle)));
                return editorials;
            }
        }

        /// <summary>
        /// All images attached with this place
        /// </summary>
        public IEnumerable<PlaceImage> Images
        {
            get
            {
                var images = new List<PlaceImage>();
                handle.ForeachImage((imageHandle) => images.Add(new PlaceImage(imageHandle)));
                return images;
            }
        }

        /// <summary>
        /// All reviews attached with this place
        /// </summary>
        public IEnumerable<PlaceReview> Reviews
        {
            get
            {
                var reviews = new List<PlaceReview>();
                handle.ForeachReview((reviewHandle) => reviews.Add(new PlaceReview(reviewHandle)));
                return reviews;
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
        }
        #endregion
    }
}
