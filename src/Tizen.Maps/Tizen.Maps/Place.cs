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
    /// Place information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Place : IDisposable
    {
        internal Interop.PlaceHandle handle;

        internal Place(Interop.PlaceHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Gets an ID string for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                return handle.Name;
            }
        }

        /// <summary>
        /// Gets a view URI for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Uri
        {
            get
            {
                return handle.Uri;
            }
        }

        /// <summary>
        /// Gets a distance for the place from the center.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Distance
        {
            get
            {
                return handle.Distance;
            }
        }

        /// <summary>
        /// Gets a geographical location for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Geocoordinates Coordinates
        {
            get
            {
                return new Geocoordinates(handle.Coordinates);
            }
        }

        /// <summary>
        /// Gets an address for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceAddress Address
        {
            get
            {
                return new PlaceAddress(handle.Address);
            }
        }

        /// <summary>
        /// Gets a rating for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceRating Rating
        {
            get
            {
                return new PlaceRating(handle.Rating);
            }
        }

        /// <summary>
        /// Gets a supplier link for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceLink Supplier
        {
            get
            {
                return new PlaceLink(handle.Supplier);
            }
        }

        /// <summary>
        /// Gets a related link for the place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceLink Related
        {
            get
            {
                return new PlaceLink(handle.Related);
            }
        }

        /// <summary>
        /// Gets all the properties attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the categories attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the attributes attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the contacts attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the editorials attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the images attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the reviews attached to this place.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
