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
        /// Gets ID string for the place.
        /// </summary>
        public string Id
        {
            get
            {
                return handle.Id;
            }
        }

        /// <summary>
        /// Gets name string for the place.
        /// </summary>
        public string Name
        {
            get
            {
                return handle.Name;
            }
        }

        /// <summary>
        /// Gets view URI for the place.
        /// </summary>
        public string Uri
        {
            get
            {
                return handle.Uri;
            }
        }

        /// <summary>
        /// Gets distance for the place from the center.
        /// </summary>
        public int Distance
        {
            get
            {
                return handle.Distance;
            }
        }

        /// <summary>
        /// Gets geographical location for the place.
        /// </summary>
        public Geocoordinates Coordinates
        {
            get
            {
                return new Geocoordinates(handle.Coordinates);
            }
        }

        /// <summary>
        /// Gets address for the place.
        /// </summary>
        public PlaceAddress Address
        {
            get
            {
                return new PlaceAddress(handle.Address);
            }
        }

        /// <summary>
        /// Gets rating for the place.
        /// </summary>
        public PlaceRating Rating
        {
            get
            {
                return new PlaceRating(handle.Rating);
            }
        }

        /// <summary>
        /// Gets supplier link for the place.
        /// </summary>
        public PlaceLink Supplier
        {
            get
            {
                return new PlaceLink(handle.Supplier);
            }
        }

        /// <summary>
        /// Gets related link for the place.
        /// </summary>
        public PlaceLink Related
        {
            get
            {
                return new PlaceLink(handle.Related);
            }
        }

        /// <summary>
        /// Gets all properties attached to this place.
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
        /// Gets all categories attached to this place.
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
        /// Gets all attributes attached to this place.
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
        /// Gets all contacts attached to this place.
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
        /// Gets all editorials attached to this place.
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
        /// Gets all images attached to this place.
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
        /// Gets all reviews attached to this place.
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

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
